//Получить пользователя.
function getUserInfoAjax() {
    $.ajax({
        type: "GET",
        url: "/User/GetCurrentUser",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#Id').val(json.id);
            $('#Firstname').val(json.firstname);
            $('#Surname').val(json.surname);
            $('#UserTypeId').val(json.userTypeId);
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}

function showAlert() {
    window.setTimeout(function () {
        $(".alert").fadeTo(500, 0);
    }, 4000);
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
            $('#editInfoModalCenter').modal('hide');
            $('.modal-backdrop').remove();
            $(document.body).removeClass("modal-open");
            getUserAjax();
            getUserInfoAjax();
            showAlert();
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}

//получить словарь типов.
function getUserTypes() {
    $.ajax({
        type: "GET",
        url: "/Dictionary/GetUserTypes",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            var sel = document.getElementById('UserTypeId');
            for (var i = 0; i < json.length; i++) {
                var opt = document.createElement('option');
                opt.innerHTML = json[i].name;
                opt.value = json[i].id;
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

//
function getUserAjax() {
    $.ajax({
        type: "GET",
        url: "/User/GetCurrentUser",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#user-name').text(json.firstname + " " + json.surname);
            $('#user-type').text(json.userTypeName);
        },
        failure: function (response) {
            console.log("Не удалось получить пользователя");
        },
        error: function (response) {
            console.log("Не удалось получить пользователя");
        }
    });
}