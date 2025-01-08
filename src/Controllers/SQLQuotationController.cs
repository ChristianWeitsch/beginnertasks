using BeginnerTasks.Models;
using BeginnerTasks.Services;
using Microsoft.AspNetCore.Mvc;


namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("MySQL/Quotes")]
    public class SqlQuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public SqlQuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotes = await _quotationService.GetAllAsync();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quote = await _quotationService.GetByIdAsync(id);
            if (quote == null)
            {
                return BadRequest("Keine Daten mit dieser ID gefunden");
            }

            return Ok(quote);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Quote quote)
        {
            if (quote == null)
            {
                return BadRequest("Ungültige Daten");
            }

            var result = await _quotationService.AddAsync(quote);
            if (result)
            {
                return Ok("Erfolgreich erstellt");
            }
            else
            {
                return BadRequest("Erstellung fehlgeschlagen");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Quote quote)
        {
            var existingQuote = await _quotationService.GetByIdAsync(quote.Id);
            if (existingQuote == null)
            {
                return BadRequest("Keine Daten gefunden");
            }

            var result = await _quotationService.UpdateAsync(quote);
            return result? Ok("Daten wurden erfolgreich gespeichert"): BadRequest("Fehler bei speichern");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _quotationService.DeleteAsync(id);

            return result ? Ok("Erfolgreich gelöscht"): BadRequest("Fehler beim löschen");
        }
    }
}