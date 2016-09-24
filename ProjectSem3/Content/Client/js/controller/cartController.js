var cart = {
    init: function () {
        cart.registerEvent();
    },
    registerEvent: function () {
        $(".shop-now").off("click").on("click", function (e) {
            e.preventDefault();
            var productId = $("#ProductGeneral_ID").val();
            var color = $(".list-color.active").data('color');
            var size = $(".pro-size.active .list-size.active").text();
            var quantity = $(".cart-plus-minus input").val();

            var cartItem = {
                Product: {
                    ID: productId
                },
                Color: color,
                Size: size,
                Quantity: quantity
            };
            $.ajax({
                url: "/Cart/AddItem",
                data: {
                    model: JSON.stringify(cartItem)
                },
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    if (response.result == true)
                    window.location.href = "/Cart/Index"
                }
            });
        });
        
        
    }
}

cart.init();