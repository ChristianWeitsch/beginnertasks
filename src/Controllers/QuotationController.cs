using BeginnerTasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("task1/[controller]")]
    public class QuotationController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var text = "Look deep into nature, and then you will understand everything better.";
            var author = "Albert Einstein";
            var category = "Nature";
            var quote = new Quote(1, text, author, category);
            var secondQuote = new Quote();
            var quoteArray = new[] { quote , secondQuote};
            return Ok(quoteArray);
        }
    }
}