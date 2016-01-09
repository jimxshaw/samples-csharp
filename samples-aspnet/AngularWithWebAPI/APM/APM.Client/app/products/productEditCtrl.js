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
        var vm = this;
        vm.product = {};
        vm.message = '';

        productResource.get({ id: 5 },
            function (data) {
                vm.product = data;
                vm.originalProduct = angular.copy(data);
            });

        if (vm.product && vm.product.productId) {
            vm.title = "Edit: " + vm.product.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalProduct);
            vm.message = "";
        };

    }
}());
