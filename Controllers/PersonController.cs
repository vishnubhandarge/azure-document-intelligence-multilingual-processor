using Azure_AI_DocumentProcessor.Data;
using Azure_AI_DocumentProcessor.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Azure_AI_DocumentProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DocAIDbContext _context;
        public PersonController(DocAIDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPerson(Person person)
        {
            _context.Peoples.Add(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }
    }
}
