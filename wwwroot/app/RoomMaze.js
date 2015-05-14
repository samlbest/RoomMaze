var phonecatApp = angular.module('RoomMaze', [
  'ngRoute',
  'RoomMazeControllers'
]);

var RoomMazeControllers = angular.module('RoomMazeControllers', []);

RoomMazeControllers.controller('HomeCtrl', ['$scope',
  function ($scope) {
    $scope.models = {
      test: 'Sam'
    };
}]);
