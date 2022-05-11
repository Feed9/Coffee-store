
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

        },
        error: function (xhr, ajaxOptions, thrownError) {
            var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

            PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

            console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });


}
