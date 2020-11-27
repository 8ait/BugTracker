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

//Редактировать информацию пользователя.
function postUserInfoAjax() {
    var user = {
        Id: $('#Id').val(),
        Firstname: $('#Firstname').val(),
        Surname: $('#Surname').val(),
        UserTypeName: "",
        UserTypeId: parseInt($('#UserTypeId').val())
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
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Информация отредактирована.");
                showAlert("alert-" + id, 0 * 450);
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

//Изменить пароль.
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
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Пароль изменен.");
                showAlert("alert-" + id, 0 * 450);
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

//Получить таблицу пользователей.
function getUserTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/User/GetUserTable?page=" + page + "&count=" + count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('users').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='4'>Пользователи в системе отсутствуют.</td></tr>").appendTo("#users");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.firstname + "</td><td>" + item.surname + "</td><td>" + item.userTypeName + "</td><td><a class='btn btn-success' href='/User/GetUser?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#users");
                    });
                }
                document.getElementById('infoUserPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('userPage').value = json.value.page;
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
            console.log("Не удалось получить ошибки пользователя.");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить ошибки пользователя.");
        }
    });
}

function getProjectTableAjax(page, count, id) {
    $.ajax({
        type: "GET",
        url: "/Project/GetUserProjectTableById?page=" + page + "&count=" + count + "&id=" + id,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('projects').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='2'>Пользователь не участвует ни в одном проекте.</td></tr>").appendTo("#projects");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td><a class='btn btn-success' href='/Project/GetProject?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#projects");
                    });
                }
                document.getElementById('infoUserProjectPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('userProjectPage').value = json.value.page;
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
            console.log("Не удалось получить проекты пользователя.");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить проекты пользователя.");
        }
    });
}

function getProjectUserTableAjax(page, count, projectId, userTypeId) {

    // Если тип руководителя.
    if (userTypeId === 1) {
        var tableId = 'projectManagers';
        var emptyMsg = "У проекта отстутсвуют руководители.";
        var errorMsg = "Не удается получить руководилей проекта.";
        var infoPageId = 'infoProjectManagerPage';
        var pageId = 'projectManagerPage'
    }

    // Если тип тестировщика.
    if (userTypeId === 2) {
        var tableId = 'projectTesters';
        var emptyMsg = "У проекта отстутсвуют тестировщики.";
        var errorMsg = "Не удается получить тестировщиков проекта.";
        var infoPageId = 'infoProjectTesterPage';
        var pageId = 'projectTesterPage'
    }

    // Если тип разработчика.
    if (userTypeId === 3) {
        var tableId = 'projectDevelopers';
        var emptyMsg = "У проекта отстутсвуют разработчики.";
        var errorMsg = "Не удается получить разработчиков проекта.";
        var infoPageId = 'infoProjectDeveloperPage';
        var pageId = 'projectDeveloperPage'
    }

    $.ajax({
        type: "GET",
        url: "/User/GetProjectUserTable?page=" + page + "&count=" + count + "&projectId=" + projectId + "&userTypeId=" + userTypeId,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById(tableId).innerHTML = "";
                if (json.value.rowDtos.length === 0) {
                    $("<tr><td colspan='4'>" + emptyMsg + "</td></tr>").appendTo("#" + tableId);
                } else {
                    json.value.rowDtos.forEach(item => {
                        var name = item.firstname + " " + item.surname;
                        $("<tr><td>" + item.firstname + "</td><td>" + item.surname + "</td><td>" + item.startDate + "</td><td><a class='btn btn-success' href='/User/GetUser?id=" + item.userId + "'>Показать &#128270;</a><button style='margin-left: 10px;' class='btn btn-danger' data-toggle='modal' data-target='#deleteUserModalCenter' onclick='setUserNameToDelete(\"" + item.id + "\"," + userTypeId + ",\"" + name + "\")'>Исключить</button></td></tr>").appendTo("#" + tableId);
                    });
                }
                document.getElementById(infoPageId).innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById(pageId).value = json.value.page;
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
            console.log(errorMsg);
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log(errorMsg);
        }
    });
}

function addUserToProjectAjax(userId, projectId) {
    var user = {
        user: userId,
        project: projectId
    };
    $.ajax({
        type: "POST",
        url: "/User/AddUserToProject",
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                getProjectUserTableAjax(1, 5, projectId, 1);
                getProjectUserTableAjax(1, 5, projectId, 2);
                getProjectUserTableAjax(1, 5, projectId, 3);
                $('#addUserModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Пользователь добавлен в проект.");
                showAlert("alert-" + id, 0 * 450);
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
            console.log("Не удалось добавить пользователя в проект.");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось добавить пользователя в проект.");
        }
    });
}

function getUsersByUserTypeAjax(userTypeId, projectId) {

    // Если тип руководителя.
    if (userTypeId === 1) {
        var modalHeader = 'Добавление нового руководителя в проект';
        var errorMsg = 'Не удалось получить список возможных руководителей для добавления';
    }

    // Если тип тестировщика.
    if (userTypeId === 2) {
        var modalHeader = 'Добавление нового тестировщика в проект';
        var errorMsg = 'Не удалось получить список возможных тестировщиков для добавления';
    }

    // Если тип разработчика.
    if (userTypeId === 3) {
        var modalHeader = 'Добавление нового разработчика в проект';
        var errorMsg = 'Не удалось получить список возможных разработчиков для добавления';
    }

    $.ajax({
        type: "GET",
        url: "/User/GetUsersByType?userTypeId=" + userTypeId + "&projectId=" + projectId,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('userSelect').innerHTML = "";
                $("#userModalLongTitle").text(modalHeader);
                json.value.forEach(item => {
                    var name = item.firstname + " " + item.surname;
                    $("<option value=" + item.id + ">" + name + "</option>").appendTo("#userSelect");
                });
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
            console.log(errorMsg);
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log(errorMsg);
        }
    });
}

function setUserNameToDelete(userId, userTypeId, name) {
    // Если тип руководителя.
    if (userTypeId === 1) {
        var modalHeader = 'Подтверждение удаления руководителя из проекта';
    }

    // Если тип тестировщика.
    if (userTypeId === 2) {
        var modalHeader = 'Подтверждение удаления тестировщика из проекта';
    }

    // Если тип разработчика.
    if (userTypeId === 3) {
        var modalHeader = 'Подтверждение удаления разработчика из проекта';
    }

    $('#deleteUserModalLongTitle').text(modalHeader);
    $('#userName').text(name);
    document.getElementById('userIdToDelete').value = userId;
}

function deleteUserFromProjectAjax(userInProjectId, projectId) {
    var deleteUser = {
        id: userInProjectId
    };
    $.ajax({
        type: "POST",
        url: "/User/DeleteUserFromProject",
        data: JSON.stringify(deleteUser),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                getProjectUserTableAjax(1, 5, projectId, 1);
                getProjectUserTableAjax(1, 5, projectId, 2);
                getProjectUserTableAjax(1, 5, projectId, 3);
                $('#deleteUserModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Пользователь удален из проекта.");
                showAlert("alert-" + id, 0 * 450);
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
            console.log("Не удалось удалить пользователя из проекта.");
        },
        error: function (response) {
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось удалить пользователя из проекта.");
        }
    });
}