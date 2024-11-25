using BeginnerTasks.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("task1/[controller]")]
    public class QuotationController : ControllerBase
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=123456;database==Weatherforcast";

        [HttpGet]
        public IActionResult Get()
        {
            var quotes = GetQuotesFromDatabase();
            return Ok(quotes);
        }

        private List<Quote> GetQuotesFromDatabase()
        {
            List<Quote> quoteList = new List<Quote>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, type, location FROM weatherinfo";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string type = reader.GetString("type");
                        string location = reader.GetString("location");
                        string category = "Weather";

                        Quote quote = new Quote(id, type, location, category);
                        quoteList.Add(quote);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler: " + ex.Message);
                }
            }

            return quoteList;
        }
    }
}
