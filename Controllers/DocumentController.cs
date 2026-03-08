using Azure_AI_DocumentProcessor.Data;
using Azure_AI_DocumentProcessor.Modals;
using Azure_AI_DocumentProcessor.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azure_AI_DocumentProcessor.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentAIService _aiService;
        private readonly TranslatorService _translator;
        private readonly DocAIDbContext _context;

        public DocumentController(DocumentAIService aiService, TranslatorService translator, DocAIDbContext context)
        {
            _aiService = aiService;
            _translator = translator;
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file, string targetLanguage = "en")
        {
            using var stream = file.OpenReadStream();

            var result = await _aiService.AnalyzeAsync(stream);

            var persons = new List<Person>();

            foreach (var table in result.Tables)
            {
                for (int row = 1; row < table.RowCount; row++)
                {
                    var name = table.Cells.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == 0)?.Content;
                    var email = table.Cells.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == 1)?.Content;
                    var phone = table.Cells.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == 2)?.Content;
                    var city = table.Cells.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == 3)?.Content;
                    var language = table.Cells.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == 4)?.Content;

                    var translatedName = await _translator.TranslateAsync(name, targetLanguage);
                    var translatedCity = await _translator.TranslateAsync(city, targetLanguage);

                    persons.Add(new Person
                    {
                        Name = translatedName,
                        Email = email,
                        Phone = phone,
                        City = translatedCity,
                        SourceLanguage = language,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            _context.Peoples.AddRange(persons);
            await _context.SaveChangesAsync();

            return Ok(persons);
        }
    }
}
