(function () {
    "use strict";

    // We reference the common.services module and define a new service factory 
    // called userAccount. 
    angular
        .module("common.services")
        .factory("userAccount", ["$resource", "appSettings", userAccount]);

    // We inject both $resource and appSettings into this service. We'll need 
    // $resource to communicate with the web api. We'll need the appSettings 
    // constant because it defines our server path. Two $resource properties are created. 
    // First is the registration property, which POST a request to /api/Account/Register. 
    // Second is the login property that returns a $resource with a loginUser method. Note 
    // that we have to change the header of the request to specify a content type of encoded. 
    // Also, by default $resource will convert our request body to JSON. The transformRequest 
    // property provides a function that'll transform the data any way we want it before
    // adding it to the request. 
    function userAccount($resource, appSettings) {
        return {
            registration: $resource(appSettings.serverPath + "/api/Account/Register", null,
                        {
                            'registerUser': { method: 'POST' }
                        }),
            login: $resource(appSettings.serverPath + "/Token", null,
                        {
                            'loginUser': {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                                transformRequest: function (data, headersGetter) {
                                    var str = [];
                                    for (var d in data) {
                                        str.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
                                    }
                                    return str.join("&");
                                }
                            }
                        })
        };
    }

})();