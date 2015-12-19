/// <reference path="../lib/angular/angular.js" />
/// <reference path="../lib/angular/angular-route.js" />
/// <reference path="../lib/jquery/jquery-2.1.4.min.js" />
var sxapp = angular.module('wdage', [
    'ngRoute',
    'ngAnimate',
    'appindex',
]);
sxapp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/home/index', {
            templateUrl:'/home/index2',
            controller: 'customMenuCtrl'
        }).
        when('/home/cusMenu', {
            templateUrl: '/home/cusMenu',
            controller:'cusMenuCtrl'
        }).
    otherwise({
        redirectTo: '/home/index2'
    });
}]);

//登陆过期跳转
sxapp.factory('authInterceptor', ['$q', function ($q) {
    return {
        response: function (response) {
            var hlocation = response.headers("myLocation");
            if (hlocation) {
                window.location.href = hlocation;
            }
            return response;
        },
        request: function (request) {
            request.headers.Angular = "ok";
            return request;
        }
    };
}]);

sxapp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
}]);