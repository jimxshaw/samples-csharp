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

        vm.registerUser = function () { };

        vm.login = function () { };
    }

})();