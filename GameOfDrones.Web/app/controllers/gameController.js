function gameController($scope, $state, $uibModal) {
    $state.go("game.new");
    $scope.game = {};
    $scope.modalInstance = {};

    $scope.openConfig = function () {
        $scope.modalInstance = $uibModal.open({
            animation: false,
            templateUrl: 'app/views/game.config.html',
            controller: 'configController'
        });
    }
}
