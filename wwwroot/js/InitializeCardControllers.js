
function InitializeCardControllers() {

    var submitButton = $("#productCard button[name='add-to-cart']").click(onAddToCartClick);
    $(".price").click(onRecalculateTotalCost);
    onRecalculateTotalCost();
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
function onRecalculateTotalCost() {
    var totalCost = Number(0);
    totalCost += Number($("#product-form input[type='radio']:checked").attr("data-price"));

    $('#product-form input:checkbox:checked').each(function () {
        totalCost += Number($(this).attr("data-price"));
    });

    $("#cart-total-cost").text(totalCost);
    console.log("Asd");
}
