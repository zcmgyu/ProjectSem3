var account = {
    init: function () {
        $("#ddlDistrict").prop('disabled', true);
        account.loadCity();
        account.stateChangeEvent();
        account.disableAllComponentInPersonalInfo();
        account.editEvent();
        account.updateEvent();
        account.cancelEvent();
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

    disableAllComponentInPersonalInfo: function () {
        $("#personalInfo input").prop('disabled', true);
        $("#personalInfo input[type='submit']").prop('disabled', false);
        $("#personalInfo select").prop('disabled', true);
    },
    enableAllComponent: function () {
        $("#personalInfo input").prop('disabled', false);
        $("#personalInfo select").prop('disabled', false);
    },
    editEvent: function () {
        $("input[value='Edit']").off('click').on('click', function (e) {
            e.preventDefault();
            //$("input[value='Edit']").addClass("hide-element");
            //$("input[value='Update']").removeClass("hide-element");
            account.showOrHide();
            account.enableAllComponent();
        });
    },
    updateEvent: function () {
        $("input[value='Update']").off("click").on("click", function (e) {
            e.preventDefault();
            var element = this;
            $.ajax(
                {
                    type: "POST",
                    url: "Manage/UpdateInfo",
                    dataType: "json",
                    data: $('#personalInfo').serialize(),
                    success: function (response) {
                        if (response.result) {
                            alert("Success");
                            //$(element).closest("form").submit();
                            accountInfo = account.getAccountInfo();
                            account.showOrHide();
                            account.disableAllComponentInPersonalInfoInPersonalInfo();
                        } else {
                            alert("Update fail");
                        }
                    },
                    error: function () {
                        alert("Fail");
                    }
                });
        });
    },

    cancelEvent: function () {
        $("input[value='Cancel']").off("click").on("click", function (e) {
            e.preventDefault();
            account.setAccountInfo(accountInfo.Firstname, accountInfo.Lastname,
                accountInfo.Address, accountInfo.City,
                accountInfo.District, accountInfo.DOB, accountInfo.Gender,
                accountInfo.PhoneNumber, accountInfo.PostCode);
            account.disableAllComponentInPersonalInfo();
            account.showOrHide();
        });
    },

    showOrHide: function () {
        $("input[value='Edit']").toggleClass("hide-element");
        $("input[value='Update']").toggleClass("hide-element");
        $("input[value='Cancel']").toggleClass("hide-element");
    },

    getAccountInfo: function () {
        var data =
        {
            Firstname: $("#Firstname").val(),
            Lastname: $("#Lastname").val(),
            Address: $("#Address").val(),
            City: $("#City").val(),
            District: $("#District").val(),
            DOB: $("#DOB").val(),
            Gender: $("#Gender").val(),
            PhoneNumber: $("#PhoneNumber").val(),
            PostCode: $("#PostCode").val()
        };
        return data;
    },
    setAccountInfo: function (firstname, lastname, address, city, district, dob, gender, phoneNumber, postCode) {
        $("#Firstname").val(firstname);
        $("#Lastname").val(lastname);
        $("#Address").val(address);
        $("#City").val(city);
        $("#District").val(district);
        $("#DOB").val(dob);
        $("#Gender").val(gender);
        $("#PhoneNumber").val(phoneNumber);
        $("#PostCode").val(postCode);
    }


}
account.init();
var accountInfo = account.getAccountInfo();
