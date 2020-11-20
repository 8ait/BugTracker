//Получить пользователя.
function getUserInfoAjax() {
    $.ajax({
        type: "GET",
        url: "/User/GetCurrentUser",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#Id').val(json.value.id);
            $('#Firstname').val(json.value.firstname);
            $('#Surname').val(json.value.surname);
            $('#UserTypeId').val(json.value.userTypeId);
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}

//Получить пользователя.
function postUserInfoAjax() {
    var user = {
        Id: $('#Id').val(),
        Firstname: $('#Firstname').val(),
        Surname: $('#Surname').val(),
        UserTypeName: "",
        UserTypeId: $('#UserTypeId').val()
    };

    $.ajax({
        type: "POST",
        url: "/User/EditUserInformation",
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (json) {
            if (json.isSuccess) {
                $('#editInfoModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");
                getUserAjax();
                getUserInfoAjax();
                addInfo("alert-" + 0, "Информация отредактирована.");
                showAlert("alert-" + 0, 0 * 450);
            } else {
                for (var i = 0; i < json.errors.length; i++) {
                    var id = getRandomInt(0, 9999);
                    addError("alert-" + id, json.errors[i]);
                    showAlert("alert-" + id, i * 450);
                }
            }
        },
        failure: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить пользователя");
        }
    });
}

//Получить справочник типов.
function getUserTypes() {
    $.ajax({
        type: "GET",
        url: "/Dictionary/GetUserTypes",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            var sel = document.getElementById('UserTypeId');
            for (var i = 0; i < json.value.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = json.value[i].name;
                opt.value = json.value[i].id;
                sel.appendChild(opt);
            }
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}

//Получить пользователя.
function getUserAjax() {
    $.ajax({
        type: "GET",
        url: "/User/GetCurrentUser",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#user-name').text(json.value.firstname + " " + json.value.surname);
            $('#user-type').text(json.value.userTypeName);
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}

function postUserPasswordAjax() {
    var userPasswordInfo = {
        Id: $('#Id').val(),
        OldPassword: $('#OldPassword').val(),
        NewPassword: $('#NewPassword').val(),
        RepeatNewPassword: $('#RepeatNewPassword').val()
    };

    $.ajax({
        type: "POST",
        url: "/User/EditUserPassword",
        data: JSON.stringify(userPasswordInfo),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (json) {
            if (json.isSuccess) {
                $('#editPasswordModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");
                addInfo("alert-" + 0, "Пароль изменен.");
                showAlert("alert-" + 0, 0 * 450);
            } else {
                for (var i = 0; i < json.errors.length; i++) {
                    var id = getRandomInt(0, 9999);
                    addError("alert-" + id, json.errors[i]);
                    showAlert("alert-" + id, i * 450);
                }
            }
        },
        failure: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось изменить пароль.");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось изменить пароль.");
        }
    });
}