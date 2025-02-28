using CodingTracker.selnoom.Helpers;
using Spectre.Console;

namespace CodingTracker.selnoom.UI;

internal static class MainMenu
{
    internal static void ShowMenu()
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
                default:
                    return;
            }
        }
    }
}
