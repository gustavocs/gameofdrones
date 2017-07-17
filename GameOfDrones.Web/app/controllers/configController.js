function configController($scope, Restangular) {
    var lastMove = 0;
    var loadMoves = function () {
        Restangular.one('Config').get().then(function (data) {
            $scope.config = data;
            lastMove = data.Moves.length;
        }
        , function () {
            console.log(data);
        });
    }

    loadMoves();

    $scope.addMove = function () {
        var newMove = {
            MoveId: ++lastMove,
            Name: 'NewMove',
            Kills: {
                MoveId: $scope.config.Moves[0].MoveId
            }
        };
        $scope.config.Moves.push(newMove);
        $scope.updateMoves();
    }
    $scope.removeMove = function (moveId) {
        if(confirm('Are you sure?')){
            $scope.config.Moves = arrayExtensions.remove($scope.config.Moves, function (b) {
                return b.MoveId == moveId
            });
        }
    }
    $scope.updateMoves = function (close) {

        var movesToUpdate = new Array();
        for(var i = 0; i < $scope.config.Moves.length; i++){
            var newMove = {
                MoveId: $scope.config.Moves[i].MoveId,
                Name: $scope.config.Moves[i].Name,
                KillsMoveId: $scope.config.Moves[i].Kills.MoveId
            };
            movesToUpdate.push(newMove);
        }

        Restangular.one('Config').post('', { Moves: movesToUpdate }).then(function (data) {
            loadMoves();
            if(close)
                $scope.$$prevSibling.modalInstance.dismiss();
        }
        , function () {
            alert("There was an error in the request.");
        });
    }
}
