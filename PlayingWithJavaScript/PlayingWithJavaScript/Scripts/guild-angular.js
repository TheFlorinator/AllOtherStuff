(function () {

    var app = angular.module("app", []);

    app.controller("ctrl", function ($scope, $http) {

        $scope.name = "Dave";

        $scope.showAlert = function () {
            alert($scope.name);
        };

        //$http.get("/api/Persons")

        $.getJSON("/api/Persons")
           .done(function (people) {
               console.log("success");
               $scope.people = people;
               $scope.$apply();
           })
           .fail(function () {
               console.log("failed!");
           });
    });
})();