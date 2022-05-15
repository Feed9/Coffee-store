
function setUpAddToCartEvent() {

    var submitButton = $("#productCard button[name='add-to-cart']").click(onAddToCartClick);
}

function onAddToCartClick() {

    var url = $('#product-form').attr('action');
    
    var CartItem = $('#product-form').serialize();
    $.ajax({
        type: "POST",
        url: url,
        data: CartItem,
        success: function (data) {
            $("#productCard").modal('hide');
        },
        error: function (xhr, ajaxOptions, thrownError) {

            if (xhr.status = "401") {
                $("#productCard").modal('hide');
                $("#UserLoginModal").modal('show');
            }

            console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });


}
