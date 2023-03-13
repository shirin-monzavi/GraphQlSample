using GraphQlSample.Model;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _consumer.GetAllOwners(graphQLQuery));
        }

        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetOwner(Guid ownerId, [FromQuery] GraphQLQuery graphQLQuery)
        {
            return Ok(await _consumer.GetOwner(graphQLQuery, ownerId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] GraphQLQuery? graphQLQuery)
        {
            return Ok(await _consumer.CreateOwner<object>(graphQLQuery));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] GraphQLQuery? graphQLQuery)
        {
            return Ok(await _consumer.UpdateOwner<object>(id, graphQLQuery));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            return Ok(await _consumer.DeleteOwner<object>(id));
        }
    }
}
