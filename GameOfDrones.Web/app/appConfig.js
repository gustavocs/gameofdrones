app.config(function ($stateProvider, $urlRouterProvider, RestangularProvider, apiConfig) {
    $urlRouterProvider.otherwise("/game");

    RestangularProvider.setBaseUrl(apiConfig.url);

    $stateProvider
        .state('game', {
            url: '/game'
            , templateUrl: 'app/views/game.html'
            , controller: gameController

        })
        .state('game.new', {
            url: '/new'
            , templateUrl: 'app/views/game.main.html'
            , controller: mainController

        })
        .state('game.round', {
            url: '/round/:id'
            , templateUrl: 'app/views/game.round.html'
            , controller: roundController
            , params: { Game : null }
        })
        .state('game.winner', {
            url: '/winner'
                , templateUrl: 'app/views/game.winner.html'
                , controller: winnerController
                , params: { Winner: null }
        });
});

