// tripEditorController.js

(function() {
    "use strict";

    angular.module("app-trips")
        .controller("tripEditorController", tripEditorController);

    function tripEditorController($routeParams) {
        var vm = this;

        // Keep in mind our app-trips controller calls the route parameter
        // of each trip as :tripName. So here we have to also use 
        // tripName in order for binding to work.
        vm.tripName = $routeParams.tripName;
        vm.stop = [];
        vm.errorMessage = "";
        vm.isBusy = true;
    }

})();