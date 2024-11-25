using MySql.Data.MySqlClient;

namespace BeginnerTasks.Interfaces;

public interface ISqlConnectionService
{
    MySqlConnection Databaseconnection { get; set; }
}