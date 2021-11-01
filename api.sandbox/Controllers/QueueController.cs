using Microsoft.AspNetCore.Mvc;
using queue.connector.Interfaces;
using queue.connector.Model;
using System.Threading.Tasks;

namespace api.sandbox.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QueueController : BaseApiController
    {
        private readonly IMessageConnector<NQMessage> _queue;

        public QueueController(IMessageConnector<NQMessage> queue)
        {
            _queue = queue;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNotification([FromBody] NQMessage nqmessage)
        {  
            await _queue.AddMessageAsync(nqmessage);
            return Ok(nqmessage.Id);
        }
    }
}
