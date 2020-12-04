function getProjectTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/Project/GetUserProjectTable?page="+page+"&count="+count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('projects').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='2'>Вы не участвуете ни в одном проекте.</td></tr>").appendTo("#projects");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td><a class='btn btn-success' href='Project/GetProject?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#projects");
                    });
                }
                document.getElementById('infoProjectPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('projectPage').value = json.value.page;
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
            if (response.status === 403) {
                showAuthorise();
                return;
            }
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить проекты пользователя.");
        }
    });
}

function getProjectAllTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/Project/GetProjectAllTable?page=" + page + "&count=" + count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('projects').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='2'>Проекты отсутствуют в системе.</td></tr>").appendTo("#projects");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td><a class='btn btn-success' href='Project/GetProject?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#projects");
                    });
                }
                document.getElementById('infoProjectAllPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('projectAllPage').value = json.value.page;
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
            var err = "Не удалось получить проекты.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
                return;
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось получить проекты.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function deleteProjectAjax(id) {
    var projectToDelete = id;
    $.ajax({
        type: "DELETE",
        url: "/Project/Delete",
        data: JSON.stringify(projectToDelete),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                window.location.href = "/Project";
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
            var err = "Не удалось удалить проект.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
                return;
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось удалить проект.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}
