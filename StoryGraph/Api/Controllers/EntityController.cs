using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KVP.StoryGraph.Api.ViewModel;
using KVP.StoryGraph.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/entity")]
    public class EntityController : Controller
    {
        public EntityController(TestService service)
        {
            
        }


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
                new Character()
                {
                    Id = "adx",
                    Name = "Kristian Videmark Parkov",
                    Creation = new DateTime(1980, 08, 09),
                    Destruction = null,
                    Relations = new List<Relation>()
                    {
                        new Relation()
                        {
                            RelationRole = "Creator",
                            Entity = new EntitySummary()
                            {
                                Type = "Character",
                                Id = "bdx",
                                Name = "Liva Rausch Parkov",
                            }
                        }
                    }
                }
            };
        }
    }
}