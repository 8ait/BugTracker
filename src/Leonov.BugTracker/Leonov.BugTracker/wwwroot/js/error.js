function getErrorTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/Error/GetUserErrorTable?page=" + page + "&count=" + count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('errors').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='4'>Вы не связаны ни с одной ошибкой.</td></tr>").appendTo("#errors");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td>" + item.dateTime + "</td><td>" + item.originAreaName + "</td><td><a class='btn btn-success' href='/Error/GetError?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#errors");
                    });
                }
                document.getElementById('infoErrorPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('errorPage').value = json.value.page;
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
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить ошибки пользователя.");
        }
    });
}

function getProjectErrorTableAjax(page, count, id) {
    $.ajax({
        type: "GET",
        url: "/Error/GetProjectErrorTable?page=" + page + "&count=" + count + "&id=" + id,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('projectErrors').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='4'>У проекта отсутствуют ошибки.</td></tr>").appendTo("#projectErrors");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td>" + item.dateTime + "</td><td>" + item.originAreaName + "</td><td><a class='btn btn-success' href='/Error/GetError?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#projectErrors");
                    });
                }
                document.getElementById('infoProjectErrorPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('projectErrorPage').value = json.value.page;
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
            console.log("Не удалось получить ошибки проекта.");
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить ошибки проекта.");
        }
    });
}

function getErrorAllTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/Error/GetErrorAllTable?page=" + page + "&count=" + count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('errors').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='2'>Ошибки отсутствуют в системе.</td></tr>").appendTo("#errors");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td>" + item.createDate + "</td><td>" + item.originAreaName + "</td><td>" + item.errorStatusName + "</td><td>" + item.createUserName + "</td><td>" + item.responsibleUserName + "</td><td><a class='btn btn-success' href='Error/GetError?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#errors");
                    });
                }
                document.getElementById('infoErrorAllPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('errorAllPage').value = json.value.page;
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
            var err = "Не удалось получить ошибки.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось получить ошибки.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function deleteErrorAjax(id) {
    var errorToDelete = id;
    $.ajax({
        type: "DELETE",
        url: "/Error/Delete",
        data: JSON.stringify(errorToDelete),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                window.location.href = "/Error";
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
            var err = "Не удалось удалить ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось удалить ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function getErrorStatusesAjax(errorId) {
    $.ajax({
        type: "GET",
        url: "/Error/GetErrorStatuses?id=" + errorId,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('changeStatusSelect').innerHTML = "";
                if (json.value.length === 0) {
                    
                } else {
                    json.value.forEach(item => {
                        $("<option value=" + item.id + ">" + item.name + "</option>").appendTo("#changeStatusSelect");
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
            var err = "Не удалось получить статусы ошибок.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось получить статусы ошибок.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function changeErrorStatusAjax(id, errorStatusId) {
    var response = {
        Id: id,
        ErrorStatusId: errorStatusId
    };
    $.ajax({
        type: "POST",
        url: "/Error/ChangeStatusError",
        data: JSON.stringify(response),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                $('#changeStatusErrorModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");
                UpdateErrorStatusAjax(response.Id);
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Статус ошибок изменен.");
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
            var err = "Не удалось изменить  ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось удалить ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function UpdateErrorStatusAjax(id) {
    $.ajax({
        type: "GET",
        url: "/Error/GetErrorStatus?id=" + id,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('selectErrorStatus').value = json.value;
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
            var err = "Не удалось изменить  ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось удалить ошибку.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}