// In this currentUser service, we'll define key customer data and 
// methods to get and set that data.
// Any angular code that injects this service can get or set the user 
// profile information. 

(function () {
    "user strict";

    // We get the reference to the common.services module and register 
    // our new factory service. 
    angular
        .module("common.services")
        .factory("currentUser", currentUser);

    function currentUser() {
        // We define the properties of our user profile.
        // We store the username in case we want to display it somewhere.
        // We need to store the access token when the user successfully 
        // logs in.  
        var profile = {
            isLoggedIn: false,
            username: "",
            token: ""
        };

        // The setProfile method sets the property values. 
        var setProfile = function (username, token) {
            profile.username = username;
            profile.token = token;
            profile.isLoggedIn = true;
        };

        // This returns the profile data. 
        var getProfile = function () {
            return profile;
        };

        return {
            setProfile: setProfile,
            getProfile: getProfile
        }

    }

})();
