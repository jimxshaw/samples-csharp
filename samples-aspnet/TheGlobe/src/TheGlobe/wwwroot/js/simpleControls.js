// simpleControls.js
(function() {
    "use strict";

    angular.module("simpleControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        // Directives return an object with well know properties in it
        // that are used to define what should be used in the directive.
        return {
            scope: {
                show: "=displayWhen"
            }, // Scope is the object of which we're binding out waitCursor.
            restrict: "E", // Restrict waitCursor to be only used with the element tag style e.g. <wait-cursor></wait-cursor>.
            templateUrl: "/views/waitCursor.html"
        };
    }

})();
