var HomeCtrl = function ($scope) {
    $scope.models = {
      test: 'Sam'
    };
}

HomeCtrl.$inject = ['$scope'];
var RoomCtrl = function($scope) {
	$scope.models = {
		me: 'hi'
	};
};

RoomCtrl.$inject = ['$scope']
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
