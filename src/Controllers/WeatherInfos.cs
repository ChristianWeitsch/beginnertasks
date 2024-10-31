using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeginnerTasks.Models
{
    public class WeatherInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!; // MongoDB ObjectId

        public int id { get; set; }   // Stelle sicher, dass diese Eigenschaft int ist
        public string? type { get; set; }   // Nullable
        public string? location { get; set; } // Nullable
        public string? date { get; set; }   // Nullable
    }
}
