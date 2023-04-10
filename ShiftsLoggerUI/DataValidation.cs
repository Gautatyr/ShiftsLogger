using static ShiftsLoggerUI.Helpers;

namespace ShiftsLoggerUI;

public static class DataValidation
{
    public static int GetNumberInput(string message = "")
    {
        if (message != "") Console.WriteLine(message);

        string userInput = Console.ReadLine();
        int number;

        while (!int.TryParse(userInput, out number))
        {
            string error = $"{userInput} is not a valid number. Please try again.";
            DisplayError(error);
            userInput = Console.ReadLine();
        }
        return number;
    }

    public static string GetTextInput(string message = "")
    {
        Console.WriteLine(message);
        string textInput = Console.ReadLine();

        while (string.IsNullOrEmpty(textInput))
        {
            DisplayError("Input can't be empty !");
            Console.WriteLine(message);
            textInput = Console.ReadLine();
        }

        return textInput;
    }

    public static int GetShiftIdInput(string message = "")
    {
        int id = GetNumberInput(message);

        while (!ShiftExists(id))
        {
            DisplayError($"The ID: {id} is invalid.");
            id = GetNumberInput(message);
        }

        return id;
    }

    public static DateTime GetShiftInput(string message = "")
    {
        Console.WriteLine(message);

        string input = Console.ReadLine();

        while(!DateTime.TryParseExact(input, "hh:MM", System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out _))
        {
            DisplayError("Invalid Format, try again");
            input = Console.ReadLine();
        }

        DateTime shift = DateTime.ParseExact(input, "hh:MM", System.Globalization.CultureInfo.InvariantCulture,
                                             System.Globalization.DateTimeStyles.None);

        return shift;
    }
}
