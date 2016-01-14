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

        productResource.query({ search: vm.searchCriteria }, function (data) {
            vm.products = data;
        });

        //// We're hard coding the products to display in the view in JSON.
        //// Comment them out when using the newly created mock products repo.
        //vm.products = [
        //{
        //    "productId": 1,
        //    "productName": "Leaf Rake",
        //    "productCode": "GDN-0011",
        //    "releaseDate": "March 19, 2009",
        //    "description": "Leaf rake with 48-inch wooden handle.",
        //    "price": 19.95
        //},
        //{
        //    "productId": 2,
        //    "productName": "Garden Cart",
        //    "productCode": "GDN-0023",
        //    "releaseDate": "March 18, 2010",
        //    "description": "15 gallon capacity rolling garden cart",
        //    "price": 32.99
        //},
        // {
        //     "productId": 5,
        //     "productName": "Hammer",
        //     "productCode": "TBX-0048",
        //     "releaseDate": "May 21, 2013",
        //     "description": "Curved claw steel hammer",
        //     "price": 8.99
        // },
        // {
        //     "productId": 8,
        //     "productName": "Saw",
        //     "productCode": "TBX-0022",
        //     "releaseDate": "May 15, 2009",
        //     "description": "15-inch steel blade hand saw",
        //     "price": 11.55
        // },
        // {
        //     "productId": 10,
        //     "productName": "Video Game Controller",
        //     "productCode": "GMG-0042",
        //     "releaseDate": "October 15, 2002",
        //     "description": "Standard two-button video game controller",
        //     "price": 35.95
        // }
        //];
    }
}());
