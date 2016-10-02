// app-trips.js
(function () {
    "use script";

    // Modules are defined with a name and an array that could be 
    // filled with dependencies.
    // Angular routing allows for client-side routes.
    angular
        .module("app-trips", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {
            // A route is provide and an object to specified on how we're
            // to use that route.
            $routeProvider.when("/",
            {
                controller: "tripsController",
                controllerAs: "vm", // This is the controller's alias.
                templateUrl: "/views/tripsView.html"
            });

            $routeProvider.when("/editor",
            {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            });

            // This is what we do if none of the routes match.
            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();