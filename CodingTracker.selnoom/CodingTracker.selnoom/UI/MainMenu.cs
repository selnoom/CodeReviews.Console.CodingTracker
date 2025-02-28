using CodingTracker.selnoom.Data;
using CodingTracker.selnoom.Helpers;
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

                    break;
                case 2:
                    CreateMenu(repository);
                    break;
                default:
                    return;
            }
        }
    }

    internal static void CreateMenu(CodingHoursRepository repository)
    {
        //TODO
        // Add validation to check if first date is before second date. Also, let user return to main menu. 
        string startTime;
        string endTime;

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold]Please type the starting time of your coding session (Format: yyyy-MM-dd HH:mm):[/]");
        startTime = Validation.ValidateDateInput();

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold]Now, type the ending time of your coding session (Format: yyyy-MM-dd HH:mm):[/]");
        endTime = Validation.ValidateDateInput();

        repository.CreateRecord(startTime, endTime);
        AnsiConsole.MarkupLine("[bold green]Entry was successfully created! Press enter to continue[/]");
        AnsiConsole.Prompt(new TextPrompt<string>("").AllowEmpty());
    }
}
