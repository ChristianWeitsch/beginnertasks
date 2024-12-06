using BeginnerTasks.Interfaces;
using MySql.Data.MySqlClient;

namespace BeginnerTasks.Services;

public class SqlConnectionService : ISqlConnectionService
{
    private const string _connectionString =
        "server=127.0.0.1;uid=root;pwd=1234;database=quotation";

    public MySqlConnection Databaseconnection { get; set; }

    public SqlConnectionService()
    {
        Databaseconnection = new MySqlConnection(_connectionString);
        if(Databaseconnection is null)
        {
            throw new Exception("Connection failed");
        }
        MigrateDatabase();
    }

    public void MigrateDatabase()
    {
        
    }
}