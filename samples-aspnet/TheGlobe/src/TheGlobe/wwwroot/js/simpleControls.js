// simpleControls.js
(function() {
    "use strict";

    angular.module("simpleControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        // Directives return an object with well know properties in it
        // that are used to define what should be used in the directive.
        return {
            templateUrl: "/views/waitCursor.html"
        };
    }

})();
