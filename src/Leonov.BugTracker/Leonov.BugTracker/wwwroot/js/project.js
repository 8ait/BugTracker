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
                if (json.value.projectInfoDtos.length == 0) {
                    $("<tr><td colspan='2'>Вы не участвуете ни в одном проекте.</td></tr>").appendTo("#projects");
                } else {
                    json.value.projectInfoDtos.forEach(item => {
                        $("<tr><td>" + item.name + "</td><td><a class='btn btn-success' href=" + item.id + ">Показать &#128270;</a></td></tr>").appendTo("#projects");
                    });
                }
                document.getElementById('infoPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
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
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить проекты пользователя.");
        }
    });
}
