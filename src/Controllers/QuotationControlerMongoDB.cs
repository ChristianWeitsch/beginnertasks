using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json.Serialization;

namespace BeginnerTasks.Controllers
{
    [ApiController]
    [Route("MongoDB/[controller]")]
    public class QuotationControllerMongoDB : ControllerBase
    {
        private readonly IMongoCollection<WeatherInfo> _weatherCollection;

        public QuotationControllerMongoDB(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration.GetConnectionString("WeatherForCast"));
                var database = client.GetDatabase("WeatherData");
                _weatherCollection = database.GetCollection<WeatherInfo>("Data");

                
                var command = new BsonDocument { { "ping", 1 } };
                database.RunCommand<BsonDocument>(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler bei der Verbindung zur Datenbank: " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var WeatherData = await GetWeatherDataFromDatabase();
            if (WeatherData == null || WeatherData.Count == 0)
            {
                return NotFound("Hier könnten Ihre Daten stehen");
            }
            return Ok(WeatherData);
        }

        private async Task<List<WeatherInfo>> GetWeatherDataFromDatabase()
        {
            try
            {
                return await _weatherCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Abrufen der Daten: " + ex.Message);
                return new List<WeatherInfo>();
            }
        }
    }

    internal class WeatherInfo
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }
    }
}
