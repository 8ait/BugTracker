﻿function getAuditTableAjax(page, count) {
    $.ajax({
        type: "GET",
        url: "/Audit/GetUserAuditTable?page=" + page + "&count=" + count,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('audits').innerHTML = "";
                if (json.value.rowDtos.length == 0) {
                    $("<tr><td colspan='3'>У вас отсутствуют аудиты.</td></tr>").appendTo("#audits");
                } else {
                    json.value.rowDtos.forEach(item => {
                        $("<tr><td>" + item.about + "</td><td>" + item.createDate + "</td><td>" + item.errorStatusName + "</td></tr>").appendTo("#audits");
                    });
                }
                document.getElementById('infoAuditPage').innerHTML = json.value.page + " из " + json.value.countOfPages;
                document.getElementById('auditPage').value = json.value.page;
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