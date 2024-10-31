using System.Security.Cryptography.X509Certificates;
using BeginnerTasks.Models;
using MySql.Data.MySqlClient;

namespace BeginnerTasks.Services.Quotationservice;

public class Quotationservice{
   // private readonly ILogger<Quotationservice> _logger;

    /*public Quotationservice(ILogger<Quotationservice>logger){
        _logger = logger;
    }*/

    public List<Quote> GetQuotesFromDatabase()
        {
            List<Quote> quoteList = new List<Quote>();
            SQLConnectionService sqlconnectionservice =  new SQLConnectionService();
            var connection = sqlconnectionservice.Databaseconnection;
            SQLConnectionService sqlconnectionservice2 =  new SQLConnectionService();
            var connection2 = sqlconnectionservice.Databaseconnection;
            SQLConnectionService sqlconnectionservice3 =  new SQLConnectionService();
            var connection3 = sqlconnectionservice.Databaseconnection;
            Console.WriteLine($"{sqlconnectionservice3.connectioncounter}");
           
            try
            {
                connection.Open();
                string query = "SELECT id, type, location FROM weatherinfo LIMIT 16 OFFSET 4";

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
        

        return quoteList;
        }
}