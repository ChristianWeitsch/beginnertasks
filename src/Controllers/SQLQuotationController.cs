using BeginnerTasks.Models;
using BeginnerTasks.Services;
using Microsoft.AspNetCore.Mvc;


namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("MySQL/[controller]")]
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
        public IActionResult Get()
        {
            var quotes = _quotationservice.GetQuotesFromDatabase();
            return Ok(quotes);
        }
    }
}