using GraphQL;
using GraphQL.Types;
using GraphQlSample.GraphQls.GraphQLQueries;
using GraphQlSample.Model;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetOwner(Guid ownerId ,[FromQuery] GraphQLQuery graphQLQuery)
        {
            var owners = await _consumer.GetOwner(graphQLQuery, new  { id = ownerId });
            return Ok(owners);
        }
    }
}
