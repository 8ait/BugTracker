function addError(alertId, msg) {
    var newDiv = document.createElement("div");
    newDiv.className = "alert alert-danger alert-dismissible fade show";
    newDiv.innerHTML = "<strong>Ошибка:</strong> " + msg + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
    newDiv.id = alertId;
    newDiv.role = "alert";

    document.getElementById("alerts").appendChild(newDiv);
}

function addInfo(alertId, msg) {
    var newDiv = document.createElement("div");
    newDiv.className = "alert alert-success alert-dismissible fade show";
    newDiv.innerHTML = "<strong>Успешно:</strong> " + msg + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
    newDiv.id = alertId;
    newDiv.role = "alert";

    document.getElementById("alerts").appendChild(newDiv);
}

function showAlert(alertId, ms) {
    $("#" + alertId).delay(ms).fadeTo(4000, 500).slideUp(500,
        function() {
            $("#" + alertId).slideUp(500);
            $("#" + alertId).remove();
        });
}

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min; //Максимум не включается, минимум включается
}
