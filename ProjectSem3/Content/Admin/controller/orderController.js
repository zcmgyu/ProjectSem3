var order = {
    init: function () {
        order.registerEvent();
    },
    registerEvent: function () {
        $("#list-status li a").click(function () {
            var statusKey = $(this).data("order-status");
            var statusValue = $(this).text();
            var orderId = $("#orderId").val();
            $.ajax({
                url: "/Admin/Order/ChangeStatus",
                type: "POST",
                dataType: "json",
                data: {status: statusKey, orderId: orderId},
                success: function (response) {
                    if (response.result == true) {
                        alert("Update Status Successful");
                        window.location.reload(true);
                    } else {
                        alert("Update Status fail");
                    }
                }
            })


        });
    }
}

order.init();