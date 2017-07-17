using GameOfDrones.Models;
using GameOfDrones.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameOfDrones.API.Controllers
{
    public class ConfigController : ApiController
    {
        private IConfigService _service;
        public ConfigController(IConfigService service)
        {
            _service = service;
        }

        [ResponseType(typeof(GameConfig))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<GameConfig>(HttpStatusCode.OK, _service.GetConfig());
        }

        // PUT api/values/5
        public HttpResponseMessage Post([FromBody] GameConfig config)
        {
            try
            {
                _service.UpdateConfig(config);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            
        }

    }
}
