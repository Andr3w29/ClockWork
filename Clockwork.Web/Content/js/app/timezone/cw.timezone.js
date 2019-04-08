var TimeZone = {
    baseurl:"http://localhost:33961/api/timezone/",
    initControls: function () {   
        $.ajax({
            url: this.baseurl + "gettimezones",
            contentType:"application/json",
            type: "GET",
            success: function (response) {
                if (response.success) {
                    $.each(response.data, function (key, value) {
                        $("#dropDownTimeZones").append("<option value='" + value.value + "'>" + value.text + "</option>");
                    });
                    TimeZone.requestTimeZone('Dateline Standard Time');
                }
                else {
                    toastr.info(response.message);
                }
            },
            error: function (e) {
                toastr.error("An error has occured. Please try again later.");
            }
        });
        $(document).on("click", '#btRequest', function (e) {
            e.preventDefault(e);
            var timeZone = $("#dropDownTimeZones option:selected").val();
            if (timeZone != 'Select') {
                TimeZone.requestTimeZone(timeZone);
                CurrentTime.requestedTimeZone();
            }
            else
                toastr.info("Please select a time zone in the droplist.");
        });
       
    },
    requestTimeZone: function (timezone) {
        $.ajax({
            url: this.baseurl + "gettimezone/"+timezone,
            contentType: "application/json",
            type: "POST",
            success: function (response) {
                if (response.success) {
                    $('.header-subinfo').html(response.displayName);
                    $('#date-subinfo-label').text(response.time);
                    $('.month').text(response.month);
                    $('.day').text(response.day);
                }
                else {
                    toastr.info(response.message);
                }
            },
            error: function (e) {
                toastr.error("An error has occured. Please try again later.");
            }
        });
    }
   
};