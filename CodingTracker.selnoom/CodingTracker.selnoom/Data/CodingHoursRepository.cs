using CodingTracker.selnoom.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker.selnoom.Data;

internal class CodingHoursRepository
{
    internal string connectionString;
    internal CodingHoursRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    internal void CreateRecord(string startTime, string endTime)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var query = @"
            INSERT INTO codingtracker (StartTime, EndTime)
            Values (@startTime, @endTime)";

        connection.Execute(query, new { startTime, endTime });
    }
    
    internal void UpdateRecord(int id, string startTime, string endTime)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var query = @"
            UPDATE codingtracker
            SET StartTime = @startTime,
                EndTime = @endTime
            WHERE Id = @id";

        connection.Execute(query, new { id, startTime, endTime });
    }
    
    internal void DeleteRecord(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var query = @"
            DELETE FROM codingtracker
            WHERE Id = @id";

        connection.Execute(query, new { id });
    }

    internal List<CodingHours> GetAllRecords()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var query = @"
            SELECT Id, StartTime, EndTime FROM codingtracker";

        List<CodingHours> records = connection.Query<CodingHours>(query).ToList();

        return records;
    }
}
