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
        // This property representing a spinner for when 
        // data is loading.
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
            vm.isBusy = true;
            // Clear out any prior error messages.
            vm.errorMessage = "";

            $http.post("/api/trips", vm.newTrip)
                .then(function(response) {
                    // Promise success
                    vm.trips.push(response.data);
                    // If successful, clear out the new trip form.
                    vm.newTrip = {};

                }, function() {
                    // Promise failure
                    vm.errorMessage = "Failed to save new trip";
                })
                .finally(function() {
                    vm.isBusy = false;
                });
        };
    }
})();