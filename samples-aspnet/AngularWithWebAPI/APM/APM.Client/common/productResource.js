(function() {
    "use strict";

    // First, angular looks up the registered common.services module.
    // It registers the new custom factory service with that module.
    angular
        .module("common.services")
        .factory("productResource",
                    ["$resource",
                     "appSettings",
                     productResource]);

    // The $resource is injected in as a parameter to this function.
    // We also need the appSettings constant so we can access the defined
    // server path. The function calls the $resource function, passing in 
    // the URL to request the products. The URL is the server path plus 
    // "/api/products/". An optional :id parameter can be added after the 
    // products/. We're adding :search to specify the search parameter from 
    // the productListCtrl. 
    // The function finally returns the $resource object. 
    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/products/:search");
    }
}());