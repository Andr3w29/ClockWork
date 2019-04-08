var CurrentTime = {
    baseurl:"http://localhost:33961/api/currenttime",
    initControls: function () {   
        CurrentTime.requestedTimeZone();
    },
    requestedTimeZone: function () {
        $.ajax({
            url: this.baseurl + "/get",
            contentType: "application/json",
            type: "GET",
            success: function (response) {
                $('#time-zone-requested').empty();
                if (response.success) {
                    var trHTML = '';
                    $.each(response.data, function (i, item) {
                        trHTML += '<tr><td>' + item.displayName + '</td><td>' + item.clientIp + '</td><td>' + item.time + '</td><td>' + item.utcTime + '</td><td>' + item.createdOn + '</td></tr>';
                    });
                    $('#time-zone-requested').html(trHTML);
                }
            },
            error: function (e) {
                toastr.error("An error has occured. Please try again later.");
            }
        });
    }
   
};