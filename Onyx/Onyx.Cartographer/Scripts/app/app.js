'use strict';


// Declare app level module which depends on filters, and services
angular.module('onyx', ['onyx.filters', 'onyx.services', 'onyx.directives', 'onyx.controllers']).
  config(['$routeProvider', function($routeProvider) {
  	$routeProvider.when('/Featured', { templateUrl: 'AngularViews/Featured/index.html', controller: 'FeaturedController' });
  	$routeProvider.when('/Create', { templateUrl: 'AngularViews/Create/index.html', controller: 'CreateController' });
  	$routeProvider.when('/Create/Modify', { templateUrl: 'AngularViews/Create/modify.html', controller: 'CreateModifyController' });
  	$routeProvider.when('/About', { templateUrl: 'AngularViews/About/index.html', controller: 'CreateController' });
    $routeProvider.otherwise({ redirectTo: '/Featured' });
  }]);