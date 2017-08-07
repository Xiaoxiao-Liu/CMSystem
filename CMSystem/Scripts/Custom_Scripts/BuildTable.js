$(function () {
    $.ajax({
        url: '/Announcement/BuildAnnouncementTable',
        success: function (result) {
            $("#tableDiv").html(result);
        }
    });
});
