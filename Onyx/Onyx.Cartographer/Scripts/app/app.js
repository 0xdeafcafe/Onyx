'use strict';


// Declare app level module which depends on filters, and services
angular.module('cartographer', ['cartographer.filters', 'cartographer.services', 'cartographer.directives', 'cartographer.controllers']).
  config(['$routeProvider', function($routeProvider) {
  	$routeProvider.when('/Featured', { templateUrl: 'AngularViews/Featured/index.html', controller: 'FeaturedController' });
  	$routeProvider.when('/Create', { templateUrl: 'AngularViews/Create/index.html', controller: 'CreateController' });
  	$routeProvider.when('/About', { templateUrl: 'AngularViews/About/index.html', controller: 'CreateController' });
    $routeProvider.otherwise({ redirectTo: '/Featured' });
  }]);