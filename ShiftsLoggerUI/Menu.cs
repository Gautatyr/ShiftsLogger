using static ShiftsLoggerUI.Helpers;
using static ShiftsLoggerUI.DataValidation;
using static ShiftsLoggerUI.InterfaceApi;
using ShiftsLoggerUI.Models;
using ConsoleTableExt;

namespace ShiftsLoggerUI;

public static class Menu
{
    public static void MainMenu(string message = "")
    {
        Console.Clear();
        Console.WriteLine(message);

        Console.WriteLine("\nMAIN MENU\n");
        Console.WriteLine("- Type 1 to Add a new Shift");
        Console.WriteLine("- Type 2 to View all Shifts");
        Console.WriteLine("- Type 0 to Close the Application");

        switch (GetNumberInput())
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                AddShiftMenu();
                break;
            case 2:
                ViewAllShifts();
                break;
            default:
                string error = "Wrong input ! Please type a number between 0 and 2";
                MainMenu(DisplayError(error));
                break;
        }
    }

    private static void ViewAllShifts(string message = "")
    {
        Console.Clear();
        DisplayShifts();
        Console.WriteLine(message);

        Console.WriteLine("\nMAIN MENU\n");
        Console.WriteLine("- Type 1 to Update a shift");
        Console.WriteLine("- Type 2 to Delete a Shift");
        Console.WriteLine("- Type 0 to go back");

        switch (GetNumberInput())
        {
            case 0:
                MainMenu();
                break;
            case 1:
                int id = GetShiftIdInput();
                DateTime shiftStart = GetShiftInput("\nEnter the shift's starting time (Format: hh:MM)\n");
                DateTime shiftEnd = GetShiftInput("\nEnter the shift's ending time (Format: hh:MM)\n");

                Shift shift = new Shift(id, shiftStart, shiftEnd);

                UpdateShift(id, shift);
                break;
            case 2:
                id = GetShiftIdInput();
                //DeleteShift(id);
                break;
            default:
                string error = "Wrong input ! Please type a number between 0 and 2";
                ViewAllShifts(DisplayError(error));
                break;
        }

        ViewAllShifts();
    }

    private static void DisplayShifts()
    {
        ConsoleTableBuilder
                .From(GetShifts().Result)
                .ExportAndWriteLine();
    }

    private static void DisplayShift(int id)
    {
        List<Shift> shift = new List<Shift>
        {
            GetShift(id).Result
        };

        ConsoleTableBuilder
                .From(shift)
                .ExportAndWriteLine();
    }

    private static void AddShiftMenu()
    {
        throw new NotImplementedException();
    }
}
