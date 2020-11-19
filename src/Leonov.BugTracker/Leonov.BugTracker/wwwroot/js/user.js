$(document).ready(function () {
    $('#showGame').click(function () {
        var url = $('#gameModal').data('url');

        $.get(url, function (data) {
            $('#gameContainer').html(data);

            $('#gameModal').modal('show');
        });
    });
});