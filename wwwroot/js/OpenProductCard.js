$(function () {


    var OpenCardButton = $(".open-card").click(onOpenCardClick);
    function onOpenCardClick(event) {
        event.preventDefault();
        var id = $("input[name='product-hidden-id']").val();
        var url =  $(this).attr("href");       

        $.ajax({
            type: "GET",
            url: url,            
            success: function (data) {

                $("#productCard").html(data);
                setUpAddToCartEvent();
                $("#productCard").modal('show');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
                console.log(errorText);
            }
        });
    }
});
