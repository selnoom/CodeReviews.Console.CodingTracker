using CodingTracker.selnoom.Data;
using CodingTracker.selnoom.Helpers;
using CodingTracker.selnoom.Models;
using Spectre.Console;

namespace CodingTracker.selnoom.UI;

internal static class MainMenu
{
    internal static void ShowMenu(CodingHoursRepository repository)
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Markup("[bold underline]Coding Hours Tracker[/]\n\n");
            AnsiConsole.WriteLine("Select an option:");
            string userInput = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices(new[]
                    {
                        "1 - View all sessions",
                        "2 - Create session",
                        "3 - Edit session",
                        "4 - Delete session",
                        "0 - Exit program"
                    })
            );

            int validatedInput = Validation.ConvertMenuInputToInt(userInput);

            switch (validatedInput)
            {
                case 0:
                    AnsiConsole.Markup("[bold green]Goodbye![/]");
                    return;
                case 1:
                    ShowSessionsMenu(repository);
                    break;
                case 2:
                    CreateMenu(repository);
                    break;
                default:
                    return;
            }
        }
    }

    private static void ShowSessionsMenu(CodingHoursRepository repository)
    {
        List<CodingHours> sessions = new();
        sessions = repository.GetAllRecords();

        AnsiConsole.Clear();

        if (sessions.Count > 0)
        {
            AnsiConsole.MarkupLine("[bold]Sessions:[/]\n");
            foreach (CodingHours session in sessions)
            {
                AnsiConsole.MarkupLine($"Start Time: {session.StartTime}\t End Time: {session.EndTime}\t Duration: {Validation.FormatDuration(session.Duration)}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[bold]No sessions yet.[/]\n");
        }

        AnsiConsole.MarkupLine("\nPress enter to continue");
        AnsiConsole.Prompt(new TextPrompt<string>("").AllowEmpty());
    }

    internal static void CreateMenu(CodingHoursRepository repository)
    {
        string startTime;
        string endTime;

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold]Please type the starting time of your coding session (Format: yyyy-MM-dd HH:mm) or 0 to return to the menu:[/]");
        startTime = Validation.ValidateTimeInput();
        if (Validation.ReturnToMenu(startTime))
        {
            return;
        }

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold]Now, type the ending time of your coding session (Format: yyyy-MM-dd HH:mm) or 0 to return to the menu:[/]");
        endTime = Validation.ValidateEndTimeInput(startTime);
        if (Validation.ReturnToMenu(endTime))
        {
            return;
        }

        repository.CreateRecord(startTime, endTime);
        AnsiConsole.MarkupLine("[bold green]Entry was successfully created! Press enter to continue[/]");
        AnsiConsole.Prompt(new TextPrompt<string>("").AllowEmpty());
    }
}
