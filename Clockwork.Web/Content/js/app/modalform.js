var ModalForm = {
    clickCount: 0,
    init: function () {
        $(document).on("hidden.bs.modal", "#modal-logs-view", function () {
            $(this).data("bs.modal", null);
        });        
    },
    showLogsContainer: function (title) {
        $("#modal-logs-view").find(".modal-title").html(title);
        $("#modal-logs-view").modal({
            backdrop: 'static',
            keyboard: false
        });
    }
};