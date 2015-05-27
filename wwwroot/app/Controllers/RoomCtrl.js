var RoomCtrl = function($scope, $http) {
	$scope.models = {
		room: {}
	};
	
	var url = baseApiUrl + "/room/root";
	
	$http.get(url).
		success(function(data, status, headers, config) {
			$scope.models.room = data;
		});
};

RoomCtrl.$inject = ['$scope', '$http'];