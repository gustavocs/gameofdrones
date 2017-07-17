function roundController($stateParams, $scope, $state, Restangular) {
    var players;
    var roundMoves = new Array();

    if ($stateParams.Game != null) {
        players = $stateParams.Game.Players;
        $scope.Game = $stateParams.Game;
        $scope.Player = players[$scope.currentPlayer];
    }
    else {
        Restangular.one('Game').one($stateParams.id).get().then(function (data) {
            players = data.Players;
            winnerPlayer = arrayExtensions.find(players, function (b) {
                return b.Winner == true
            })[0]

            if (!winnerPlayer) {
                roundMoves = new Array();
                $scope.currentRound = data.Rounds.length+1;
                $scope.currentPlayer = 0;
                $scope.selectedMove = {};
            }
            else {
                $state.go('game.winner', { Winner: winnerPlayer });
            }

            $scope.Game = data;
            $scope.Player = players[$scope.currentPlayer];
        }
         , function () {
             alert("There was an error loading the game.");
         });
    }

    $scope.selectedMove = {};
    $scope.currentRound = 1;
    $scope.currentPlayer = 0;


    var loadMoves = function () {
        Restangular.one('Config').get().then(function (data) {
            $scope.moves = data.Moves;
        }
        , function () {
            console.log(data);
        });
    }
    var newMove = function () {
        $scope.selectedMove = {};

        if (players != null) {
            if (players.length > $scope.currentPlayer) {
                $scope.Player = players[$scope.currentPlayer];
            }
            else {
                newRound();
            }
        }
    }
    var newRound = function () {
        var round = {
            GameId: $stateParams.id,
            Moves: roundMoves
        };

        Restangular.one('Round').post('', round).then(function (data) {
            var winnerPlayer;

            $scope.$parent.game = data;

            if (data && data.Players) {
                winnerPlayer = arrayExtensions.find(data.Players, function (b) {
                    return b.Winner == true
                })[0]
            }
            if (!winnerPlayer) {
                roundMoves = new Array();
                $scope.currentRound++;
                $scope.currentPlayer = 0;
                $scope.Player = players[$scope.currentPlayer];
                $scope.selectedMove = {};
            }
            else {
                $state.go('game.winner', { Winner: winnerPlayer });
            }
        }
        , function () {
            alert("There was an error in the request.");
        });
    }

    newMove();
    loadMoves();

    $scope.submitMove = function () {
        if ($scope.selectedMove.move != null && $scope.selectedMove.move.MoveId > 0) {
            var move = {
                PlayerId: players[$scope.currentPlayer].PlayerId,
                MoveId: $scope.selectedMove.move.MoveId
            };
            $scope.currentPlayer++;
            roundMoves.push(move);
            newMove();
        }
    }
}

