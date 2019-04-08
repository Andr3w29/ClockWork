var ServiceLog = {
    baseurl: "http://localhost:33961/api/servicelog",
    init: function () {
        $.ajax({
            url: this.baseurl + "/getserviceogs",
            contentType: "application/json",
            cache: false,
            type: "GET",
            success: function (response) {
                if (response.success) {
                    var trHTML = '';
                    $.each(response.data, function (i, item) {
                        trHTML += '<tr><td>' + item.workStation + '</td><td>' + item.domain + '</td><td>' + item.logType + '</td><td>' + item.messageDisplay + '</td><td>' + item.createdOn + '</td><td><a data-action="viewlogs" data-id="' + item.id + '"  class="btn btn-info btn-xs" title="Edit Holiday">Read more</a></td></tr>';
                    });
                    $('#service-log').html(trHTML);
                }
            },
            error: function (e) {
                toastr.error("An error has occured. Please try again later.");
            }
        });
        $(document).on("click", "a[data-action=viewlogs]", function (e) {
            e.preventDefault(e);

            ServiceLog.viewLogs($(this).attr("data-id"));


        });
  
    },
    viewLogs: function (logid) {

        $.ajax({
            url: this.baseurl + "/getservicelogbyid/" + logid,
            contentType: "application/json",
            type: "GET",
            success: function (response) {
              
                if (response.success) {
                    $('.month').text(response.data.month);
                    $('.day').text(response.data.day);
                    $('#subinfo-request-response-label').text(response.data.logType);
                    $('#subinfo-request-response-domain').text(response.data.domain);
                    $('#subinfo-request-response-dayofweek').text(response.data.dayOfWeek);
                    $('#subinfo-request-response-time').text(response.data.time);
                    $('#subinfo-request-response-message').text(response.data.messageDisplay);
                    ModalForm.showLogsContainer("View Logs");
                  
                }
            },
            error: function (e) {
                toastr.error("An error has occured. Please try again later.");
            }
        });

        
 
    },

};