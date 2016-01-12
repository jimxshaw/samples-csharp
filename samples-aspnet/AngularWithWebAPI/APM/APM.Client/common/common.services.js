(function() {
    "use strict";

    // Register the module with angular. Add the $resource angular nuget
    // package dependency. Define the server path property where the web api is hosted, 
    // which is defined in a constant called appSettings.
    angular
        .module("common.services", ["ngResource"])
        .constant("appSettings", {
            serverPath: "http://localhost:56052/"
        });
});