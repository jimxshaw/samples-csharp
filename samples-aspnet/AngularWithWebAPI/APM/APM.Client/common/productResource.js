(function () {
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
    //function productResource($resource, appSettings) {
    //    return $resource(appSettings.serverPath + "/api/products/:search");
    //}

    // The second parameter is a null because we don't want to set a default 
    // value for the id. Third parameter is an object with the update action 
    // to send the PUT request. We have to customize $resource in this case 
    // because $resource by itself does not have an update action, so we have 
    // to write that ourselves. 
    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/products/:id", null,
                {
                    'update': {
                        method: 'PUT'
                    }
                });
    }
}());