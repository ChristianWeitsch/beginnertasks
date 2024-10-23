using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;


namespace QuotationRueckgabe.Controllers
{
    [ApiController]
    [Route("Aufgabe1/[controller]")]
    public class QuotationRueckgabe : ControllerBase
    {

        private string a = "Ich bin der erste Quote, ";
        private string b = "während ich der zweite Quote bin.";

        string[] QuotesArray = new string[] { "Ich bin das erste Element aus dem Array", "Ich bin das zweite Element aus dem Array", "Ich bin das dritte Element aus dem Array" };


        [HttpGet]
        public IActionResult Get()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, QuotesArray.Length);
            string randomQuote = QuotesArray[randomIndex];

            return Ok(a + b + " " + randomQuote);
        }

    }
}
