$(function () {
    // Declare a proxy to reference the hub.
    var mood = $.connection.moodHub;
    // Create a function that the hub can call to broadcast messages.
    mood.client.addMessage = function (message) {

        //print all data!!!

        alert(message);
        // Html encode display name and message.
        //var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        //$('#discussion').append('<li>' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            mood.server.send($('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});