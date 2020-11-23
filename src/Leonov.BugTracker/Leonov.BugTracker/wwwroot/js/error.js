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
                        $("<tr><td>" + item.name + "</td><td>" + item.dateTime + "</td><td>" + item.originAreaName + "</td><td><a class='btn btn-success' href='Error/GetError?id=" + item.id + "'>Показать &#128270;</a></td></tr>").appendTo("#errors");
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
            var id = getRandomInt(0, 9999);
            addError("alert-" + id);
            showAlert("alert-" + id, 350);
            console.log("Не удалось получить ошибки пользователя.");
        }
    });
}