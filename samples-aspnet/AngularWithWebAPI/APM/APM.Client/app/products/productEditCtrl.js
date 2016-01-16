(function () {
    "use strict";

    // We register the controller with the main angular module.
    angular
        .module("productManagement")
        .controller("ProductEditCtrl",
                     ProductEditCtrl);

    // We define the controller function, taking advantage of the 
    // controller as syntax so we don't need to pass in $scope into
    // the controller. The models and methods are defined directly on
    // the controller itself with this keyword.
    function ProductEditCtrl(productResource) {
        // We setup the controller with the "controller as" syntax.
        var vm = this;
        vm.product = {};
        vm.message = '';

        // When the product is retrieved, it's assigned to the data 
        // model. A copy is made so we can implement a cancel operation.
        // Since we're not linking any pages in this project, change the 
        // hard coded id to reach the desired product. 
        productResource.get({ id: 0 },
            function (data) {
                vm.product = data;
                vm.originalProduct = angular.copy(data);
            });

        // We set a title page depending on if it's a new or existing product.
        if (vm.product && vm.product.productId) {
            vm.title = "Edit: " + vm.product.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
        };

        // When the user clicks cancel, we revert to the saved version of the product.
        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalProduct);
            vm.message = "";
        };

    }
}());
