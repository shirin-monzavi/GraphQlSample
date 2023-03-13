using GraphQL.NewtonsoftJson;
using GraphQlSample.Entities;
using GraphQlSample.GraphQls.GraphQLTypes;
using GraphQlSample.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQlSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerConsumer _consumer;
        public OwnersController(OwnerConsumer consumer)
        {
            _consumer = consumer;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners([FromQuery] GraphQLQuery graphQLQuery)
        {
            var owners = await _consumer.GetAllOwners(graphQLQuery);
            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetOwner(Guid ownerId, [FromQuery] GraphQLQuery graphQLQuery)
        {
            var owners = await _consumer.GetOwner(graphQLQuery, ownerId);
            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> GetOwner([FromBody] GraphQLQuery? graphQLQuery)
        {
            return Ok(await _consumer.CreateOwner(graphQLQuery));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] GraphQLQuery? graphQLQuery)
        {
            return Ok(await _consumer.UpdateOwner(id, graphQLQuery));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            return Ok(await _consumer.DeleteOwner(id));
        }
    }
}
