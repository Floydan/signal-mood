$(function () {
    // Declare a proxy to reference the hub.
    var mood = $.connection.moodHub;
    // Create a function that the hub can call to broadcast messages.
    mood.client.addMessage = function (message) {
        var data = {
            "fromDate": "2017-05-04",
            "toDate": "2117-05-04"
        }
        $.ajax({
            type: "POST",
            url: "/api/mood/stats",
            data: data,
            success: success,
            dataType: "text/JSON"
        });
        //$.post("/api/mood/stats", function (data) {
        //    console.log(data);
        //    //$(".result").html(data);
        //});
        function success(data)
        {
            console.log(data);
        }
        //print all data!!!

        alert(message);
        // Html encode display name and message.
        //var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        //$('#discussion').append('<li>' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $.connection.hub.start().done(function () {
        //$('#sendmessage').click(function () {
        //    // Call the Send method on the hub.
        //    mood.server.send($('#message').val());
        //    // Clear text box and reset focus for next comment.
        //    $('#message').val('').focus();
        //});
    });
});