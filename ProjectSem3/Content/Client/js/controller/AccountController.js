var account = {
    init: function () {
        $("#ddlDistrict").prop('disabled', true);
        account.loadCity();
        account.registerEvent();
    },
    registerEvent: function(){
        $("#ddlCity").off("change").on("change", function () {
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
    loadCity: function () {
        var html = "<option value=\"\" >City</option>";
        $.ajax({
            url: "/Content/Client/json/vietnam_provinces_cities.json",
            type: "GET",
            dataType: "json",
            success: function (response) {
                var count = Object.keys(response).length;
                //alert(count);
                $.each(response, function(i, item) {
                    html += "<option value=" + i + ">" + item.name + "</option>"
                });
                $("#ddlCity").html(html);
            }
        })
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
                    } else {
                        console.log("City is valid")
                    }
                    
                });
                $("#ddlDistrict").html(html);
            }
        })
    }

}
account.init();

var register = {
    init: function() {
        register.registerEvent();
    },
    registerEvent: function () {
        $("#btnClear").on("click", function (e) {
            e.preventDefault();
            $("[type='text']").val("");
            $("[type='password']").val("");
            $("#ddlDistrict").html("<option value=''>District</option>");
            $("select").val("");
            $("#ddlDistrict").prop("disabled", true);
            alert("OK");
        });
    }
}
register.init()