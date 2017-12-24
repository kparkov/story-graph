using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KVP.StoryGraph.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Entity")]
    public class EntityController : Controller
    {
        /// <summary>
        /// Get the full list of entities.
        /// </summary>
        /// <returns>A list of entries.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Entity), 200)]
        public IEnumerable<Entity> Get()
        {
            return new List<Entity>()
            {
                new Entity() { Id = "dsx", Title = "My thing", Description = "A thing indeed."}
            };
        }
    }
}