using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker.selnoom.Data;

internal static class DatabaseInitializer
{
    internal static void InitializeDatabase(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var query = @"
            CREATE TABLE IF NOT EXISTS codingtracker (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT,
                EndTime TEXT);";

        connection.Execute(query);
    }
}
