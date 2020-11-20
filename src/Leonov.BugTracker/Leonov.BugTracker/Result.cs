namespace Leonov.BugTracker
{
    using System.Collections.Generic;

    /// <summary>
    /// Обертка резуьтата для запросов.
    /// </summary>
    public class Result<T>
    {
        /// <summary>
        /// Ошибки.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Флаг успеха.
        /// </summary>
        public bool IsSuccess => Errors == null || Errors.Count == 0;

        /// <summary>
        /// Значение.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <param name="errors"> Ошибки. </param>
        public Result(T value, List<string> errors)
        {
            Value = value;
            Errors = errors;
        }
    }

    /// <summary>
    /// Результат без значения.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Ошибки.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Флаг успеха.
        /// </summary>
        public bool IsSuccess => Errors == null || Errors.Count == 0;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors"> Ошибка. </param>
        public Result(List<string> errors)
        {
            Errors = errors;
        }
    }
}
