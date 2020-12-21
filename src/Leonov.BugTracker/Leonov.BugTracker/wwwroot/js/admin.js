//Получить таблицу аккаунтов.
function getAccountsTableAjax() {
    $.ajax({
        type: "GET",
        url: "/Admin/GetAccounts",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('accounts').innerHTML = "";
                if (json.value.length === 0) {
                    $("<tr><td colspan='4'>Аккаунты в системе отсутствуют.</td></tr>").appendTo("#accounts");
                } else {
                    json.value.forEach(item => {
                        var checked = item.active ? "checked" : "";
                        $("<tr><td>" + item.firstname + "</td><td>" + item.surname + "</td><td>" + item.userTypeName + "</td><td><input type='checkbox' id="+ item.id +" onchange='changeActive(\"" + item.id + "\")' "+ checked +"/></td></tr>").appendTo("#accounts");
                    });
                }
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
            console.log("Не удалось получить аккаунты.");
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
                return;
            }
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить аккаунты.");
        }
    });
}

function changeAccountActiveAjax(id, active) {
    var info = {
        Id: id,
        Active: active
    }
    $.ajax({
        type: "POST",
        url: "/Admin/ChangeAccountStatus",
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (json) {
            if (json.isSuccess) {
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Информация отредактирована.");
                showAlert("alert-" + id, 0 * 450);
                getAccountsTableAjax();
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
            console.log("Не удалось выполнить операцию.");
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
                return;
            }
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось выполнить операцию.");
        }
    });
}
