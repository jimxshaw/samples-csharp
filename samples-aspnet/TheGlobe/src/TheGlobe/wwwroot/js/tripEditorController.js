// tripEditorController.js

(function() {
    "use strict";

    angular.module("app-trips")
        .controller("tripEditorController", tripEditorController);

    function tripEditorController($routeParams, $http) {
        var vm = this;

        // Keep in mind our app-trips controller calls the route parameter
        // of each trip as :tripName. So here we have to also use 
        // tripName in order for binding to work.
        vm.tripName = $routeParams.tripName;
        vm.stops = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips/" + vm.tripName + "/stops")
            .then(function(response) {
                // Success
                angular.copy(response.data, vm.stops);
            }, function (err) {
                // Failure
                vm.errorMessage = "Failed to load stops: " + err;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }

})();