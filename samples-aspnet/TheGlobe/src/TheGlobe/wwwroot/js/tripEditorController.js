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

        vm.newStop = {};

        var url = "/api/trips/" + vm.tripName + "/stops";

        $http.get(url)
            .then(function(response) {
                // Success: copy over data for the retrieved collection of stops
                // and then show the map featuring those stops.
                angular.copy(response.data, vm.stops);
                _showMap(vm.stops);
            }, function (err) {
                // Failure
                vm.errorMessage = "Failed to load stops: " + err;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addStop = function() {

            vm.isBusy = true;

            $http.post(url, vm.newStop)
                .then(function(response) {
                    // Success
                    vm.stops.push(response.data);
                    _showMap(vm.stops);
                    vm.newStop = {};
                }, function(err) {
                    // Failure
                    vm.errorMessage = "Failed to add new stop: " + err;
                })
                .finally(function () {
                    vm.isBusy = false;
                });

        };
    }

    function _showMap(stops) {
        if (stops && stops.length > 0) {

            // Our stops retrieved from our backend database must be mapped into an appropriate type with
            // correct attribute specific to what the travelMap library seeks in order to display 
            // map properly.
            var mapStops = _.map(stops, function (item) {
                return {
                    lat: item.latitude,
                    long: item.longitude,
                    info: item.name
                };
            });

            // Show map
            travelMap.createMap({
                stops: mapStops,
                selector: "#map", // This is a CSS selector stating the id attribute where we'll place our map.
                currentStop: 0,
                initialZoom: 3
            });
        }
    }

})();