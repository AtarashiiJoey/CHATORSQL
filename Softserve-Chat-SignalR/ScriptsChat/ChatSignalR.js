$(function () {
    var chat = $.connection.chat;
    chat.client.addNewMessageToPage = function (name, message) {
        $('#discussion').append('<ul style="list-style-type:square"><li><strong style="color:red;font-style:normal;font-size:medium;text-transform:uppercase">' + htmlEncode(name) + '  ' + '<strong style="color:black;font-style:normal;font-size:medium;text-transform:lowercase">said</strong>'
            + '</strong>: ' + '<strong style="color:blue;font-style:oblique;font-size:medium">' + htmlEncode(message) + '</strong>' + '</li></ul>');
    };
    $('#displayname').val(prompt('enter a name we might know you by', ''));
    $('#message').focus();
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            chat.server.send($('#displayname').val(), $('#message').val());
            $('#message').val('').focus();
        });
    });
});
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}