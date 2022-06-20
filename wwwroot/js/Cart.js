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
                $(".product_count button[name='items-count']").click(onQuantityChange);
                $("#createOrderBtn").click(onCreateOrder);
                $("#modal-cart").modal('show');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
                console.log(errorText);
            }
        });
    }
    function onCreateOrder() {
        var url = $('#create-order-form').attr('action');
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                window.location.href = "/Orders/CreateOrder";
            },
            error: function (xhr, ajaxOptions, thrownError) {
                if (xhr.status = "400") {                    
                    alert(xhr.responseText);                    
                }
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
                console.log(errorText);
            }
        });
    }
    function onQuantityChange() {
        var url = "/Cart/ChangeQuantity";
        var id = $(this).attr("data-id");
        var operation = $(this).attr("data-operation");
        var item = {
            itemId: id,
            operation: operation
        }
        $.ajax({
            type: "POST",
            url: url,
            data: item,
            success: function (data) {

                $("#modal-cart").html(data);
                $(".product_count button[name='items-count']").click(onQuantityChange);
                $("#createOrderBtn").click(onCreateOrder);
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

