using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get()
        {
            var owners = await _consumer.GetAllOwners();
            return Ok(owners);
        }
    }
}
