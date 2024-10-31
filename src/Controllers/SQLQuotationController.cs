using BeginnerTasks.Services.Quotationservice;
using Microsoft.AspNetCore.Mvc;


namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("MySQL/[controller]")]
    public class SQLQuotationController : ControllerBase
    {
    
        [HttpGet]
        public IActionResult Get()
        {
            var quotationservice = new Quotationservice();

            var quotes = quotationservice.GetQuotesFromDatabase();
            return Ok(quotes);


        }

        
    }
}
