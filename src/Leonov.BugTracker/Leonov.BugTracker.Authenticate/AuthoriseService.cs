namespace Leonov.BugTracker.Authenticate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Identity;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class AuthoriseService: IAuthoriseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BugTrackerContext _context;
        private readonly ILogger _logger;

        private const byte KEY_LENGTH = 64;
        private const byte SALT_LENGTH = 64;

        private const string LOGIN_COOKIE_NAME = "login";
        private const string KEY_COOKIE_NAME = "key";

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AuthoriseService(IHttpContextAccessor httpContextAccessor,
            BugTrackerContext context,
            ILogger<AuthoriseService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task SignInAsync(SignIn signIn, List<string> errors)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == signIn.Login);
            if (user == null)
            {
                errors.Add("Пользователя с таким логином не существует.");
                return;
            }
            var passwordHash = GenerateSaltedHash(Encoding.UTF8.GetBytes(signIn.Password), user.Salt);
            if (!passwordHash.SequenceEqual(user.HashPassword))
            {
                errors.Add("Неверный пароль.");
                return;
            }

            await AuthoriseAsync(user);
        }

        /// <inheritdoc />
        public async Task SignUpAsync(SignUp signUp, List<string> errors)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(signUp.Password);
            var saltBytes = GenerateSalt();
            var hashPassword = GenerateSaltedHash(passwordBytes, saltBytes);

            var curUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == signUp.Login);
            if (curUser != null)
            {
                errors.Add("Пользователь с таким логином уже существует.");
                return;
            }

            var user = new User()
            {
                Login = signUp.Login,
                FirstName = signUp.FirstName,
                Surname = signUp.Surname,
                Salt = saltBytes,
                HashPassword = hashPassword,
                UserType = signUp.UserType
            };
            await _context.Users.AddAsync(user);
            await _context.TrySaveChangesAsync(errors);
            await AuthoriseAsync(user);
        }

        /// <inheritdoc />
        public async Task<User> GetCurrentUser()
        {
            var user = new User();
            if (IsAuthorized())
                user = await _context.Users
                    .Include(x => x.UserType)
                    .FirstOrDefaultAsync(x => x.Login == _httpContextAccessor.HttpContext.Request.Cookies[LOGIN_COOKIE_NAME]);
            return user;
        }

        /// <inheritdoc />
        public void SignOut()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(LOGIN_COOKIE_NAME);
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(KEY_COOKIE_NAME);
        }

        /// <inheritdoc />
        public bool IsAuthorized()
        {
            var cookieLogin = _httpContextAccessor.HttpContext.Request.Cookies[LOGIN_COOKIE_NAME];
            if (cookieLogin is null)
                return false;
            var keyCookie = _httpContextAccessor.HttpContext.Request.Cookies[KEY_COOKIE_NAME];
            var user = _context.Users.FirstOrDefault(x => x.Login == cookieLogin);
            var keyCookieHash = Convert.FromBase64String(keyCookie);
            return user != null && user.CookieSession.SequenceEqual(keyCookieHash);
        }

        /// <inheritdoc />
        public async Task EditPasswordAsync(UserPasswordUpdate userPasswordUpdate, List<string> errors)
        {
            var user = await _context.Users.FindAsync(userPasswordUpdate.Id);
            if (user is null)
            {
                errors.Add("Пользователя с таким Id не существует.");
                return;
            }
            var hashPassword = GenerateSaltedHash(Encoding.UTF8.GetBytes(userPasswordUpdate.OldPassword), user.Salt);
            if (!hashPassword.SequenceEqual(user.HashPassword))
            {
                errors.Add("Неверный старый пароль для пользователя.");
                return;
            }

            user.HashPassword = GenerateSaltedHash(Encoding.UTF8.GetBytes(userPasswordUpdate.NewPassword), user.Salt);

            _context.Users.Update(user);
            await _context.TrySaveChangesAsync(errors);
        }

        /// <summary>
        /// Авторизовать пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор пользователя. </param>
        private async Task AuthoriseAsync(User user)
        {
            var key = GenerateKey();
            user.CookieSession = key;
            await _context.SaveChangesAsync();
            var str = Convert.ToBase64String(key);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(LOGIN_COOKIE_NAME, user.Login);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(KEY_COOKIE_NAME, Convert.ToBase64String(key));
        }

        /// <summary>
        /// Засолить пароль.
        /// </summary>
        /// <param name="plainText"> Исходный текст. </param>
        /// <param name="salt"> Соль. </param>
        /// <returns> Хеш. </returns>
        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        /// <summary>
        /// Сгенировать рандомный ключ для куки.
        /// </summary>
        /// <returns> Ключ. </returns>
        private byte[] GenerateKey()
        {
            var key = new byte[KEY_LENGTH];
            var rand = new Random();
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = (byte)rand.Next(byte.MinValue, byte.MaxValue);
            }
            
            return key;
        }

        /// <summary>
        /// Сгенирировать соль.
        /// </summary>
        /// <returns> Соль. </returns>
        private byte[] GenerateSalt()
        {
            var salt = new byte[SALT_LENGTH];
            var rand = new Random();
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = (byte)rand.Next(byte.MinValue, byte.MaxValue);
            }

            return salt;
        }
    }
}
