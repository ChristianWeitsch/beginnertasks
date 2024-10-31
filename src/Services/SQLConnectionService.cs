using MySql.Data.MySqlClient;

namespace BeginnerTasks.Services;

public class SQLConnectionService{
    private const string _connectionString = "Server=localhost;Database=Weatherforcast;User ID=root;Password=Test123;SslMode=none;";
    public MySqlConnection? Databaseconnection{get;set;}
    public int connectioncounter{get; set;}
    private void CreateDatabaseConnection(){
        Databaseconnection = new MySqlConnection(_connectionString);
        connectioncounter++;
    }
    public SQLConnectionService(){
        if(Databaseconnection is null){
            CreateDatabaseConnection();
        }
    }
}