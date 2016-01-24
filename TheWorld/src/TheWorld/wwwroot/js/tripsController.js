//tripsController.js
(function () {
    "use strict";
    //useModule
    angular.module("app-trips")
            .controller("tripsController", tripsController);

    function tripsController($http) {

        var vm = this;
        vm.trips =[ ];

        vm.newTrip = {};

        $http.get()

        vm.addTrip = function () {
            vm.trips.push({ name: vm.newTrip.name, created: new Date() });
            vm.newTrip = {};
        };
    }

})();