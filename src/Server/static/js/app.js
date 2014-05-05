var docularApp = angular.module('docularApp', ['ngResource', 'docularControllers']);

docularApp.config(function($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            templateUrl : '/static/partials/home.html',
            controller : MainController
        })
        .when('/search', {
            templateUrl : '/static/partials/about.html',
            controller : SearchController
        });

});