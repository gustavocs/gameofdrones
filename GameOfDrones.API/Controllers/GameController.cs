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
    public class GameController : ApiController
    {
        private IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }

        [ResponseType(typeof(IEnumerable<Game>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<IEnumerable<Game>>(HttpStatusCode.OK, _service.GetAll());
        }
  
        [ResponseType(typeof(Game))]
        public HttpResponseMessage Get(int id)
        {
            Game game = _service.GetResults(id);
            return Request.CreateResponse<Game>(HttpStatusCode.OK, game);
        }

        [ResponseType(typeof(Game))]
        public HttpResponseMessage Post([FromBody] Game game)
        {
            return Request.CreateResponse<Game>(HttpStatusCode.OK, _service.Add(game));
        }

        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
