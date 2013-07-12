'use strict';


// Declare app level module which depends on filters, and services
angular.module('cartographer', ['cartographer.filters', 'cartographer.services', 'cartographer.directives', 'cartographer.controllers']).
  config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/Featured', {templateUrl: 'partials/partial1.html', controller: 'FeaturedController'});
    $routeProvider.when('/Create', {templateUrl: 'partials/partial2.html', controller: 'CreateController'});
    $routeProvider.otherwise({ redirectTo: '/Featured' });
  }]);