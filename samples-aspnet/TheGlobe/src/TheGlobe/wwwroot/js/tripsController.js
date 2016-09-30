// tripsController.js
(function() {
    "use strict";

    // Existing modules, after they've been defined, can be retrieved
    // using the same defining syntax except without the second parameter 
    // dependencies array. 
    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController($http) {
        // The this keyword in this context is the object returned from 
        // our tripsController. Abbreviated view model as vm.
        var vm = this;

        vm.trips = [];

        // This object will accept all the data about a new trip.
        vm.newTrip = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips")
            .then(function(response) {
                    // Promise success
                    angular.copy(response.data, vm.trips);
                },
                function(error) {
                    // Promise failure
                    vm.errorMessage = "Failed to load data: " + error;
                }
            ).finally(function() {
                vm.isBusy = false;
            });

        vm.addTrip = function() {
            vm.trips.push({ name: vm.newTrip.name, created: new Date() });
            // After we add the new trip from the form, we clear out the form 
            // so we don't accidentally submit the same trip over and over.
            vm.newTrip = {};
        };
    }
})();