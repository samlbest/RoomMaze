var HomeCtrl = function ($scope) {
    $scope.models = {
      test: 'Sam'
    };
}

HomeCtrl.$inject = ['$scope'];
var RoomCtrl = function($scope, $http) {
	$scope.models = {
		room: {}
	};
	
	var url = baseApiUrl + "/room/root";
	
	$http.get(url).
		success(function(data, status, headers, config) {
			debugger;
			$scope.models.room = data;
		});
};

RoomCtrl.$inject = ['$scope', '$http'];
var baseApiUrl = "http://localhost:5001/api"

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
