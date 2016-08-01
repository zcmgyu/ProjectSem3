var account = {
    init: function () {
        $("#ddlDistrict").prop('disabled', true);
        account.loadCity();
        account.stateChangeEvent();
        account.disableAllComponent();
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
        $("#ddlDistrict").prop('disabled', false);
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
    },

    disableAllComponent: function() {
        $("input").prop('disabled', true);
        $("input[type='submit']").prop('disabled', false);
        $("select").prop('disabled', true);
    },
    enableAllComponent: function () {
        $("input").prop('disabled', false);
        $("select").prop('disabled', false);
    },
    editEvent: function() {
        $("input[value='Edit']").off('click').on('click', function () {
            $("input[value='Edit']").addClass("hide-element");
            $("input[value='Update']").removeClass("hide-element");
            account.enableAllComponent();
        });
    },
    updateEvent: function() {
        $("input[value='Update']").off("click").on("click", function (e) {
            e.preventDefault();
            $.ajax(
                {
                    url: "",
                    type: "POST",
                    
                }
            );
        });
    },

}
account.init();
