using System.Data;
using BeginnerTasks.Interfaces;
using BeginnerTasks.Models;
using MySql.Data.MySqlClient;


namespace BeginnerTasks.Services;

public class OldQuotationservice : IOldQuotationservice
{
    private readonly ILogger<OldQuotationservice> _logger;
    private readonly MySqlConnection _sqlConnection;

    public string? filterType { get; private set; }
    public string? filterValue { get; private set; }

    public OldQuotationservice(ISqlConnectionService sqlConnectionService, ILogger<OldQuotationservice> logger)
    {
        _sqlConnection = sqlConnectionService.Databaseconnection;
        _logger = logger;
    }

    public bool CreateQuoteInDatabase(Quote quote)
    {
        var query = $"INSERT INTO quotation (id, name, quote, type) VALUES ({quote.Id}, '{quote.Name}', '{quote.QuoteText}', '{quote.Type}' )";
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

    public List<Quote> GetQuotesFromDatabase(string? filterType = null, string? filterValue = null, string? filterLength = null)
    {
        List<Quote> quoteList = new List<Quote>();
        int length = 10;

        
        if (!string.IsNullOrEmpty(filterLength) && int.TryParse(filterLength, out int parsedLength))
        {
            length = parsedLength;
        }

        try
        {
            if (_sqlConnection.State == ConnectionState.Closed)
                _sqlConnection.Open();

            
            string query = "SELECT id, name, quote, type FROM quotation";

            
            if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterValue))
            {
                query += " WHERE " + filterType + " LIKE @filterValue";
            }

            
            query += " LIMIT @limit";

            MySqlCommand cmd = new MySqlCommand(query, _sqlConnection);

            
            if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterValue))
            {
                cmd.Parameters.AddWithValue("@filterValue", $"%{filterValue}%");
            }

            
            cmd.Parameters.AddWithValue("@limit", length);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    string quoteText = reader.GetString("quote");
                    string type = reader.GetString("type");

                    Quote quote = new Quote(){Id=id, Name=name, QuoteText=quoteText, Type=type};
                    quoteList.Add(quote);
                }
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

        var query = $"UPDATE quotation SET name='{quote.Name}', quote='{quote.QuoteText}', type='{quote.Type}' WHERE id='{quote.Id}'";
        var cmd = new MySqlCommand(query, _sqlConnection);

        try
        {
            if (_sqlConnection.State == ConnectionState.Closed)
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

    public bool DeleteQuoteFromDatabase(int id)
    {
        var query = $"DELETE FROM quotation WHERE id = {id}";
        var cmd = new MySqlCommand(query, _sqlConnection);
        

        try
        {
            if (_sqlConnection.State == ConnectionState.Closed)
                _sqlConnection.Open();
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
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
}