using System.Data;
using BeginnerTasks.Interfaces;
using BeginnerTasks.Models;
using MySql.Data.MySqlClient;

namespace BeginnerTasks.Services;

public class Quotationservice : IQuotationservice
{
    private readonly ILogger<Quotationservice> _logger;
    private readonly MySqlConnection _sqlConnection;

    public Quotationservice(ISqlConnectionService sqlConnectionService, ILogger<Quotationservice> logger)
    {
        _sqlConnection = sqlConnectionService.Databaseconnection;
        _logger = logger;
    }

    public bool CreateQuoteInDatabase(Quote quote)
    {
        var query = $"INSERT INTO weatherinfo (id, type, location, category) VALUES ({quote.Id}, '{quote.Type}', '{quote.Location}', '{quote.Category}')";
        var cmd = new MySqlCommand(query, _sqlConnection);
        
        try
        {
            if(_sqlConnection.State == ConnectionState.Closed)
                _sqlConnection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
        finally
        {
            if (_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
        }
    }

    public List<Quote> GetQuotesFromDatabase()
    {
        List<Quote> quoteList = new List<Quote>();

        try
        {
            if(_sqlConnection.State == ConnectionState.Closed)
                _sqlConnection.Open();
            string query = "SELECT id, type, location, category FROM weatherinfo";

            MySqlCommand cmd = new MySqlCommand(query, _sqlConnection);
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string type = reader.GetString("type");
                string location = reader.GetString("location");
                string category = reader.GetString("category");

                Quote quote = new Quote(id, type, location, category);
                quoteList.Add(quote);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: " + ex.Message);
        }
        finally
        {
            if (_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
        }

        return quoteList;
    }

    public bool UpdateQuoteFromDatabase(Quote quote)
    {
        throw new NotImplementedException();
    }

    public bool DeleteQuoteFromDatabase(int id)
    {
        throw new NotImplementedException();
    }
}