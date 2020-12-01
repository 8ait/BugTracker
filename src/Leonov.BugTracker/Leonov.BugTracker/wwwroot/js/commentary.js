function addCommentaryAjax(errorId, parentId, commentary) {
    var response = {
        ErrorId: errorId,
        ParentId: parentId,
        Value: commentary
    };
    $.ajax({
        type: "POST",
        url: "/Commentary/AddCommentary",
        data: JSON.stringify(response),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                $('#commentaryModalCenter').modal('hide');
                $('.modal-backdrop').remove();
                $(document.body).removeClass("modal-open");

                getCommentariesByErrorId(errorId);
                var id = getRandomInt(0, 9999);
                addInfo("alert-" + id, "Комментарий добавлен.");
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
            var err = "Не удалось добавить комментарий.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось добавить комментарий.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function getCommentariesByErrorId(errorId) {

    function createCommentary(id, userName, createDate, parentName, value, childrens) {
        $("<div class='commentary'><div style='margin:10px;' id=" + id + "></div><div class='row'><div class='col-3'><div class='info-commentary'>" + userName + "</div></div><div class='col-9'><div class='info-commentary'><textarea disabled='disabled' readonly='readonly' style='width: 100%; height: 100px; resize: none'>" + value + "</textarea><div class='row' style='margin-top: 20px;'><div class='col-9'>" + createDate + "</div><div class='col-3'><button class='btn btn-info' data-toggle='modal' data-target='#commentaryModalCenter' onclick='setAttributes(\"" + id + "\")'>Ответить</button></div></div></div></div></div></div>").appendTo("#commentaries");
        if (parentName !== null) {
            $("<strong>Ответ на комментарий пользователя " + parentName + "</strong>").appendTo("#" + id);
        }
        if (childrens !== undefined) {
            childrens.forEach(children => {
                createCommentary(children.id, children.userName, children.createDateTime, children.parentUsername, children.value, children.childrens);
            });
        }
    }

    $.ajax({
        type: "GET",
        url: "/Commentary/GetCommentariesByError?errorId=" + errorId,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.isSuccess) {
                document.getElementById('commentaries').innerHTML = "";
                json.value.forEach(item => {
                    createCommentary(item.id, item.userName, item.createDateTime, item.parentUsername, item.value, item.childrens);
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
            var err = "Не удалось добавить комментарий.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        },
        error: function (response) {
            if (response.status === 403) {
                showAuthorise();
            }
            var id = getRandomInt(0, 9999);
            var err = "Не удалось добавить комментарий.";
            addError("alert-" + id, err);
            showAlert("alert-" + id, 350);
            console.log(err);
        }
    });
}

function setAttributes(id) {
    document.getElementById('parentId').value = id;
}