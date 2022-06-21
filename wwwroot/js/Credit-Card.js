$(function () {
    var onCart = $("#payment-method").change(onClick);
    function onClick() {
        var d = onCart.val();
        if (d != 0) {
            $("#credit-card").hide();
            return;
        }
        $("#credit-card").show();



    }
});