using ChatService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly List<Message> _messages;
        
        public MessageController(List<Message> context)
        {
            _messages = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetAllMessage()
        {
            var messages = _messages;
            return Ok(messages);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Message>>> GetMessage(Message message)
        {
            foreach (var m in _messages)
            {
                if (m == message)
                {
                    return Ok(message);
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Message>>> CreatedMessage(Message message)
        {
            _messages.Add(message);
            return Ok(await GetAllMessage());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Message>>> UpdateMessage(Message message)
        {

            foreach (var m in _messages.ToList())
            {
                if (m == message)
                {
                    _messages.Remove(m);
                    _messages.Add(message);
                }
            }
            return NotFound();
        }
        
        [HttpDelete]
        public async Task<ActionResult<List<Message>>> DeleteMessage(Message message)
        {
            _messages.Remove(message);
            return NoContent();
        }
    }
}
