var account = {
    init: function () {
        $("#ddlDistrict").prop('disabled', true);
        account.loadCity();
        account.stateChangeEvent();
    },

    loadCity: function () {
        var html = "<option value=\"\" >City</option>";
        $.ajax({
            url: "/Content/Client/json/vietnam_provinces_cities.json",
            type: "GET",
            dataType: "json",
            success: function (response) {
                var count = Object.keys(response).length;
                $.each(response, function (i, item) {
                    html += "<option value=" + i + ">" + item.name + "</option>"
                });
                $("#ddlCity").html(html);
                setSelectedCity();
                account.getSelectedCity();
            }
        })
    },

    getSelectedCity: function () {
        var selectedDistrictValue = $('#ddlCity').find(':selected').val();
        account.loadDistrict(selectedDistrictValue);
        $("#ddlDistrict").prop('disabled', true);
    },

    loadDistrict: function (city) {
        var html = "";
        $.ajax({
            url: "/Content/Client/json/vietnam_provinces_cities.json",
            type: "GET",
            dataType: "json",
            success: function (response) {
                //var count = Object.keys(response).length;
                //alert(count);
                $.each(response, function (i, item) {
                    var cities = item.cities;
                    if (i === city) {
                        $.each(item.cities, function (j, jItem) {
                            html += "<option value=" + j + ">" + item.cities[j] + "</option>"
                        });
                    }
                });
                $("#ddlDistrict").html(html);
                setSelectedDistrict();
                $("#ddlDistrict").prop('disabled', false);
            }
        })
    },
    stateChangeEvent: function () {
        $("#ddlCity").off("change").on("change", function () {
            //$("#ddlCity option").prop("selected", false);
            var city = $(this).val();
            console.log("City = " + city);
            if (city != "") {
                account.loadDistrict(city);
                $("#ddlDistrict").prop('disabled', false);
            }
            else {
                $("#ddlDistrict").html("<option>District</option>")
                $("#ddlDistrict").prop('disabled', true);
            }
        });
    }
}
account.init();
