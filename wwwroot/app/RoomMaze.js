var RoomMaze = angular.module('RoomMaze', ['ngRoute']);

RoomMaze.controller('RoomCtrl', RoomCtrl);
RoomMaze.controller('HomeCtrl', HomeCtrl);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/room', {
            templateUrl: '/Template/Room',
            controller: RoomCtrl
        });
}

configFunction.$inject = ['$routeProvider'];

RoomMaze.config(configFunction);
