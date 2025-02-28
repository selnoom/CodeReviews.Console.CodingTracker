using CodingTracker.selnoom.Data;
using CodingTracker.selnoom.UI;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("CodingTrackerDb");

DatabaseInitializer.InitializeDatabase(connectionString);

MainMenu.ShowMenu();