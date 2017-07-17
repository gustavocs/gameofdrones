function mainController($state, $scope, Restangular) {
    $scope.title = 'Welcome to Game of Drones!';

    $scope.newGame = function () {
        var game = {
            Players: [
                { Number: 1, Name: $scope.player1name },
                { Number: 2, Name: $scope.player2name }]
        };

        Restangular.one('Game').post('', game).then(function (data) {
            console.log(data);
            $state.go('game.round', { id: data.GameId, Game : data });
        }
        ,function () {
            alert("There was an error in the request.");
        });
    }
}