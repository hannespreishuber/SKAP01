angular.module('App').factory('trainingFactory', function ($resource) {
    return $resource('/api/trainings/:id');
});