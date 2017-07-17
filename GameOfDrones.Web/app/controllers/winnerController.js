function winnerController($stateParams, $scope, Restangular) {
    if ($stateParams.Winner != null) {
        $scope.Player = $stateParams.Winner;
    }
}