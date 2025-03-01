﻿using Spectre.Console;
using System.Text.RegularExpressions;

namespace CodingTracker.selnoom.Helpers;

internal static class Validation
{
    internal static int ConvertMenuInputToInt (string input)
    {
        return int.Parse(input.Split('-')[0].Trim());
    }

    internal static string ValidateDateInput()
    {
        string startTimeInput = AnsiConsole.Ask<string>("");
        while (!DateTime.TryParseExact(startTimeInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime))
        {
            AnsiConsole.MarkupLine("[bold red]Invalid input. Please try again.[/]\n");
            startTimeInput = AnsiConsole.Ask<string>("Enter date (yyyy-MM-dd HH:mm):\n\n");
        }
        return startTimeInput;
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
