using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GameOfDrones.Models;
using GameOfDrones.Services;

namespace GameOfDrones.API.Controllers
{
    public class RoundController : ApiController
    {
        private IConfigService _configService;
        private IGameService _gameService;
        private IMoveService _moveService;
        private IRoundService _roundService;

        public RoundController(IConfigService configService, IGameService gameService, IMoveService moveService, IRoundService roundService)
        {
            _configService = configService;
            _gameService = gameService;
            _roundService = roundService;
            _moveService = moveService;
        }

        [ResponseType(typeof(IEnumerable<Round>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<IEnumerable<Round>>(HttpStatusCode.OK, _roundService.GetAll());
        }
  
        [ResponseType(typeof(Round))]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse<Round>(HttpStatusCode.OK, _roundService.GetById(id));
        }

        [ResponseType(typeof(Game))]
        public HttpResponseMessage Post([FromBody] Round round)
        {
            round.WinnerPlayerId = CheckRoundWinner(round);
            _roundService.Add(round);

            Game game = _gameService.GetResults(round.GameId);

            return Request.CreateResponse<Game>(HttpStatusCode.OK, game);
        }


        private int? CheckRoundWinner(Round round)
        {
            var movesList = round.Moves.ToList();
            var winners = movesList.FindAll(p => movesList.Exists(m => _moveService.Kills(p.MoveId.Value, m.MoveId.Value)));

            if (winners != null && winners.Count == 1)
                return winners.FirstOrDefault().PlayerId;
            else return null;
        }

    }
}
