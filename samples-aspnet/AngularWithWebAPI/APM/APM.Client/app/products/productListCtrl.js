(function () {
    "use strict";

    // We register the controller with the main angular module.
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ["productResource",
                         ProductListCtrl]);

    // We define the controller function, taking advantage of the 
    // controller as syntax so we don't need to pass in $scope into
    // the controller. The models and methods are defined directly on
    // the controller itself with this keyword.
    function ProductListCtrl(productResource) {
        var vm = this;

        // By specifying GDN here, we'll filter the list of products 
        // with a product code of GDN. We can later bind the search 
        // criteria to a text box on the UI to allow user input of 
        // the search string.  
        vm.searchCriteria = "GDN";

        // The first object in the .query method is very important. If a 
        // parameter is passed, in this example it's search, in the $resource 
        // method and that parameter is not defined in the $resource path, the 
        // parameter will automatically be added to the URL as a query string. 
        // If a parameter is in both the $resource method and the $resource path 
        // then the parameter is added as an extension to the URL. For example, 
        // search is both below and in the productResource.js $resource path so 
        // the URL will be extended to /api/products/GDN.
        //productResource.query({ search: vm.searchCriteria }, function (data) {
        //    vm.products = data;
        //});

        // To use OData querying, write the query in the first parameter object. 
        // We could use variables to simplify querying as well:
        // vm.searchCriteria = "GDN"
        // vm.sortProperty = "Price"
        // vm.sortDirection = "desc"
        productResource.query({
            $filter: "contains(ProductCode, 'GDN') and Price ge 3 and Price le 17",
            $orderby: "Price desc"
        }, function (data) {
            vm.products = data;
        });

    }
}());
