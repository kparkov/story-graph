using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KVP.StoryGraph.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Entity")]
    public class EntityController : Controller
    {
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return new List<Entity>()
            {
                new Entity() { Id = "dsx", Title = "My thing", Description = "A thing indeed."}
            };
        }
    }
}