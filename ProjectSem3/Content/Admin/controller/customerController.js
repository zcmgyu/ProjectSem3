var customer = function () {

    var initPickers = function () {
        //init date pickers
        $('.date-picker').datepicker({
            rtl: App.isRTL(),
            autoclose: true
        });
    }

    var handleOrders = function () {

        var grid = new Datatable();

        grid.init({
            src: $("#datatable_customer"),
            onSuccess: function (grid) {
                // execute some code after table records loaded
            },
            onError: function (grid) {
                // execute some code on network or other general error  
            },
            loadingMessage: 'Loading...',
            dataTable: { // here you can define a typical datatable settings from http://datatables.net/usage/options 
                // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/scripts/datatable.js). 
                // So when dropdowns used the scrollable div should be removed. 
                //"dom": "<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'<'table-group-actions pull-right'>>r>t<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'>>",

                "lengthMenu": [
                    [10, 20, 50, 100, 150, -1],
                    [10, 20, 50, 100, 150, "All"] // change per page values here
                ],
                "pageLength": 10, // default record count per page
                "ajax": {
                    "url": "LoadCustomerToTable", // ajax source
                },
                "order": [
                    [1, "asc"]
                ], // set first column as a default sort by asc
                "processing": true,
                "serverSide": true,
                //"dom": '<"top"i>rt<"bottom"lp><"clear">',
                "columns": [
                    { "data": "ForCheckbox" },
                    { "data": "Fullname" },
                    { "data": "DisplayGender" },
                    { "data": "DisplayDOB" },
                    { "data": "FullAddress" },
                    { "data": "Email" },
                    { "data": "Phone" },
                    { "data": "DisplayStatus" },
                    { "data": "ForAction" }
                ],
            }
        });

        // handle group actionsubmit button click
        grid.getTableWrapper().on('click', '.table-group-action-submit', function (e) {
            e.preventDefault();
            var action = $(".table-group-action-input", grid.getTableWrapper());
            if (action.val() != "" && grid.getSelectedRowsCount() > 0) {
                grid.setAjaxParam("customActionType", "group_action");
                grid.setAjaxParam("customActionName", action.val());
                grid.setAjaxParam("id", grid.getSelectedRows());
                grid.getDataTable().ajax.reload();
                grid.clearAjaxParams();
            } else if (action.val() == "") {
                alert({
                    type: 'danger',
                    icon: 'warning',
                    message: 'Please select an action',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            } else if (grid.getSelectedRowsCount() === 0) {
                alert({
                    type: 'danger',
                    icon: 'warning',
                    message: 'No record selected',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            }
        });

    }
    var handleSearch = function () {
        $(document).ready(function () {
            // DataTable
            var table = $('#datatable_customer').DataTable();

            // Apply the search
            $("#btnSearch").click(function () {
                //var test = table.columns(1).search($("input[name='ID']").val().trim());
                //table.columns(2).search($("input[name='product_name']").val().trim());
                //table.columns(3).search($("input[name='product_category']").val().trim());
                //table.columns(4).search($("input[name='product_price_from']").val().trim());
                //table.columns(4).search($("input[name='product_price_to']").val().trim());
                //table.columns(5).search($("input[name='product_promotionprice_from']").val().trim());
                //table.columns(5).search($("input[name='product_promotionprice_to']").val().trim());
                table.draw(); 
            });
        });

    }

    return {

        //main function to initiate the module
        init: function () {

            initPickers();
            handleOrders();
            handleSearch();
        }

    };

}();

jQuery(document).ready(function() {    
    customer.init();
});