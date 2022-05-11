$(function () {
    var onCart = $("#open-cart").click(onCartClick);
    function onCartClick(event) {
        event.preventDefault();

        var url = $(this).attr("href");
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {

                $("#modal-cart").html(data);                
                $("#modal-cart").modal('show');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
                console.log(errorText);
            }
        });
    }
});
