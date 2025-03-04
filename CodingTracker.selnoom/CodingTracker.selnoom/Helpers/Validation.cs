using Spectre.Console;
using System.Text.RegularExpressions;

namespace CodingTracker.selnoom.Helpers;

internal static class Validation
{
    internal static int ConvertMenuInputToInt (string input)
    {
        return int.Parse(input.Split('-')[0].Trim());
    }

    internal static string ValidateTimeInput()
    {
        string startTimeInput = AnsiConsole.Ask<string>("");
        while (!DateTime.TryParseExact(startTimeInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime))
        {
            if (ReturnToMenu(startTimeInput))
            {
                return "0";
            }

            AnsiConsole.MarkupLine("[bold red]Invalid input. Please try again.[/]\n");
            startTimeInput = AnsiConsole.Ask<string>("Enter date (yyyy-MM-dd HH:mm):\n\n");
        }
        return startTimeInput;
    }

    internal static string ValidateEndTimeInput(string startTime)
    {
        string endTime;

        DateTime parsedStartTime = DateTime.ParseExact(
        startTime,
        "yyyy-MM-dd HH:mm",
        null,
        System.Globalization.DateTimeStyles.None);

        while (true)
        {
            endTime = ValidateTimeInput();

            if (ReturnToMenu(endTime))
            {
                return "0";
            }

            DateTime parsedEndTime = DateTime.ParseExact(
            endTime,
            "yyyy-MM-dd HH:mm",
            null,
            System.Globalization.DateTimeStyles.None);

            if (parsedStartTime > parsedEndTime)
            {
                AnsiConsole.MarkupLine("[bold red]The end time cannot be before the start time. Please try again.[/]\n");
            }
            else
            {
                return endTime;
            }
        }
    }

    internal static bool ReturnToMenu(string timeInput)
    {
        return timeInput.Trim() == "0";
    }

    internal static string FormatDuration(TimeSpan duration)
    {
        string formattedDuration;

        
        return formattedDuration = $"{(int)duration.TotalDays} days, {duration.Hours:D2} hours, {duration.Minutes:D2} minutes";
        
    }

    //internal static int ValidateMainMenuInput (string userInput)
    //{
    //    int validatedInput;
    //    userInput = userInput.Trim();

    //    while (true)
    //    {
    //        if (!int.TryParse(userInput, out validatedInput))
    //        {
    //            userInput = AnsiConsole.Ask<string>("[bold red]Invalid input. Please try again.[/]");
    //            continue;
    //        }

    //        if (validatedInput < 0 || validatedInput > 4)
    //        {
    //            userInput = AnsiConsole.Ask<string>("[bold red]The selected option does not exist. Please try again.[/]");
    //            continue;
    //        }

    //        return validatedInput;
    //    }
    //}
}
