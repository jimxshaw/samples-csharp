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

        // The $resoruce methods have the following general structure.
        // HTTP GET "class" actions: Resource.action([parameters], [success], [error]);
        // Non-GET instance actions: instance.$actio([parameters], [success], [error]);
        // The success and error callback functions are optional.

        // When the product is retrieved, it's assigned to the data 
        // model. A copy is made so we can implement a cancel operation.
        // Since we're not linking any pages in this project, change the 
        // hard coded id to reach the desired product. 
        productResource.get({ id: 4 },
            function (data) {
                vm.product = data;
                vm.originalProduct = angular.copy(data);
            },
            function (response) {
                // The message is bound to the view so users will see the message.
                vm.message = response.statusText + "\r\n";
                if (response.data.exceptionMessage) {
                    // If an exception occurs, the exception message becomes the
                    // view message that users see.
                    vm.message += response.data.exceptionMessage;
                }
            });

        // We set a title page depending on if it's a new or existing product.
        if (vm.product && vm.product.productId) {
            vm.title = "Edit: " + vm.product.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
            // First, we clear any text from our message.
            vm.message = "";

            // If the product has an id, we assume the request is an update so we 
            // call our custom $update method from productResource.js and pass in 
            // the productId as the parameter. This will issue a PUT request defining 
            // the id of the product to save in the URL and pass the product data in 
            // the body of the request. The second argument is the success callback 
            // function. If the update is successful, we'll notify the user.
            if (vm.product.productId) {
                vm.product.$update({ id: vm.product.productId },
                    function (data) {
                        vm.message = "Save Complete";
                    },
                    function (response) {
                        vm.message = response.statusText + "\r\n";
                        if (response.data.exceptionMessage) {
                            vm.message += response.data.exceptionMessage;
                        }
                    });
            }
            else {
                // If there is no product id, we assume we're saving a new product. 
                // So we call the built-in $resource save method. This will send a 
                // POST request and pass the entered product from the body of the 
                // request. The save function argument is the success callback. 
                // If the save is successful, we'll notify the user. We'll also 
                // update the product property with the product returned from 
                // the response. Recall that we're using the originalProduct variable 
                // in our cancel functionality. It retains the original product data. 
                // So if users have unsaved changes and clicks the cancel button, we 
                // can return to the original product version without having to 
                // re-retrieve the product from the server. We update the variable here 
                // because we're assigning the product id on the server and we want to 
                // ensure the updated product with a new id is stored in the original 
                // product variable.  
                vm.product.$save(function (data) {
                    vm.originalProduct = angular.copy(data);

                    vm.message = "Save Complete";
                },
                function (response) {
                    vm.message = statusText = "\r\n";
                    if (response.data.exceptionMessage) {
                        vm.message += response.data.exceptionMessage;
                    }
                });
            }
        };

        // When the user clicks cancel, we revert to the saved version of the product.
        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalProduct);
            vm.message = "";
        };

    }
}());
