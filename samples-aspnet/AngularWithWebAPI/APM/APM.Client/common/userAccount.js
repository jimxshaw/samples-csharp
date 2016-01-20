(function () {
    "use strict";

    // We reference the common.services module and define a new service factory 
    // called userAccount. 
    angular
        .module("common.services")
        .factory("userAccount", ["$resource", "appSettings", userAccount]);

    // We inject both $resource and appSettings into this service. We'll need 
    // $resource to communicate with the web api. We'll need the appSettings 
    // constant because it defines our server path. A custom $resource method 
    // is created called registerUser, which POST a request to /api/Account/Register.
    function userAccount($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/Account/Register", null,
                {
                    'registerUser': { method: 'POST' }
                });
    }

})();