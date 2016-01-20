// As with all angular controllers, this one starts as an IIFE.
(function () {
    'use strict';

    // We get the key angular module and register our controller with 
    // that module. This controller will use a service to handle the 
    // user account functions, such as the regustration function. We 
    // call this service userAccount. 
    angular
        .module("productManagement")
        .controller("MainCtrl", ["userAccount", MainCtrl]);

    // We inject the userAccount service as a dependency. 
    function MainCtrl(userAccount) {
        var vm = this;
        vm.isLoggedIn = false;
        vm.message = '';
        // This userData object defines the data that'll be submitted 
        // to the web api as part of the registration process. How do 
        // we know what fields to include? According to the web api 
        // documentation, the email, password and confirmPassword fields 
        // are mandatory. We added the userName because it's part of the 
        // login feature. 
        vm.userData = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: ''
        };

        // We need to pass 3 fields to the register account api: email, 
        // password and confirm password. Since we didn't create a confirm 
        // password box, we simply assign password to confirmPassword for 
        // convenience in this case. We then called the registerUser method 
        // from our userAccount service. The first argument is the userData, 
        // which contains the properties required by the register method. The 
        // second argument is a callback function when successful. The callback 
        // sets a success message, clears the confirmPassword property since we 
        // don't need it anymore and automatically logs in the user after registration.
        // The third parameter is a function used for error and exceptions handling.
        vm.registerUser = function () {
            vm.userData.confirmPassword = vm.userData.password;

            userAccount.registerUser(vm.userData,
                function (data) {
                    vm.confirmPassword = "";
                    vm.message = "Registration successful";
                    vm.login();
                },
                function (response) {
                    vm.isLoggedIn = false;
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage) {
                        vm.message += response.data.exceptionMessage;
                    }
                    // Validation errors
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState[key] + "\r\n";
                        }

                    }
                });
        };

        vm.login = function () { };
    }

})();