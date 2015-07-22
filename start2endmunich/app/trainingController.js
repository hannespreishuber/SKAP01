angular.module('App').controller('trainingController', function ($scope, trainingFactory) {
    $scope.trainings = trainingFactory.query();
    $scope.save = function (vm) {
        vm.datum = new Date(vm.datum);
        trainingFactory.save(vm);

    };

    var rproxy = $.connection.myHub1;
    rproxy.on('nachhausetelefonieren', function (t) {
        $scope.trainings.push(t);
        $scope.$apply();
    });

    $.connection.hub.start();


});