using BeginnerTasks.Models;
using BeginnerTasks.Services;
using Microsoft.AspNetCore.Mvc;


namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("MySQL/Quotes")]
    public class SQLQuotationController : ControllerBase
    {
        private readonly IQuotationservice _quotationservice;
        
        public SQLQuotationController(IQuotationservice quotationservice)
        {
            _quotationservice = quotationservice;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Quote quote)
        {
            var result = _quotationservice.CreateQuoteInDatabase(quote);
            return result ? Ok("Creation successful") : BadRequest("Creation failed");
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? filterType = null, [FromQuery] string? filterValue = null, string? filterLenght = null)
        {
            var quoteList = _quotationservice.GetQuotesFromDatabase(filterType, filterValue, filterLenght);


            if (filterLenght == "0")
            {
                return NotFound("Deine Filtereinstellung unter LenghLimit ist auf 0!");
            }
            if (quoteList.Count == 0)
            {
                return NotFound("Es wurden keine Daten gefunden, die mit dem Filter übereinstimmen!");
            }


            return Ok(quoteList);
        }


        [HttpPut]
        public IActionResult Update([FromBody] Quote quote)
        {
            var isSuccessful = _quotationservice.UpdateQuoteFromDatabase(quote);
            return isSuccessful ? Ok("Update successful") : BadRequest("Update failed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var isSuccessful = _quotationservice.DeleteQuoteFromDatabase(id);
            return isSuccessful ? Ok("Deleted successful") : BadRequest("Delete failed");
        }
    }
}