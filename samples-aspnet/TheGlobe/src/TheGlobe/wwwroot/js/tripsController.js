// tripsController.js
(function() {
    "use strict";

    // Existing modules, after they've been defined, can be retrieved
    // using the same defining syntax except without the second parameter 
    // dependencies array. 
    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController() {
        // The this keyword in this context is the object returned from 
        // our tripsController. Abbreviated view model as vm.
        var vm = this;

        vm.trips = [
        {
            name: "US Trip",
            created: new Date()
        },
        {
            name: "World Trip",
            created: new Date()
        }
        ];

        // This object will accept all the data about a new trip from the form.
        vm.newTrip = {};

        vm.addTrip = function() {
            alert(vm.newTrip.name);
        };
    }
})();