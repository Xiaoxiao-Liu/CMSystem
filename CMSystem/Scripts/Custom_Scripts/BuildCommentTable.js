$(function () {
    $.ajax({
        url: '/Comment/BuildCommentTable',
        success: function (res) {
            $("#tableDivCom").html(res);
        }
        
    });
});