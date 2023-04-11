using static ShiftsLoggerUI.Helpers;
using static ShiftsLoggerUI.DataValidation;
using static ShiftsLoggerUI.InterfaceApi;
using ShiftsLoggerUI.Models;
using ConsoleTableExt;
using System.Globalization;

namespace ShiftsLoggerUI;

public static class Menu
{
    public static void MainMenu(string error = "")
    {
        Console.Clear();
        if (!string.IsNullOrEmpty(error)) DisplayError(error);

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
                ViewAllShifts();
                break;
            case 2:
                ViewAllShifts();
                break;
            default:
                error = "Wrong input ! Please type a number between 0 and 2";
                MainMenu(error);
                break;
        }
    }

    private static void ViewAllShifts(string error = "")
    {
        Console.Clear();
        DisplayShifts();
        if (!string.IsNullOrEmpty(error)) DisplayError(error);

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

                //UpdateShift(id, shift);
                break;
            case 2:
                id = GetShiftIdInput();
                //DeleteShift(id);
                break;
            default:
                error = "Wrong input ! Please type a number between 0 and 2";
                ViewAllShifts(error);
                break;
        }

        ViewAllShifts();
    }

    private static void DisplayShifts()
    {
        List<Shift> unformatedShifts = GetShifts().Result;
        List<ShiftDTODisplay> formatedShifts = new List<ShiftDTODisplay>();
        
        foreach (Shift shift in unformatedShifts)
        {
            formatedShifts.Add(new ShiftDTODisplay
            {
                Id = shift.Id,
                Start = shift.Start.ToString("HH:mm"),
                End = shift.End.ToString("HH:mm"),
            });

            if (shift.End < shift.Start)
            {
                TimeSpan day = TimeSpan.Parse("24:00:00");
                TimeSpan dif = shift.Start - shift.End;
                var temp = (day - dif).ToString();
                formatedShifts.Last().Duration = temp.Substring(3);
            }
            else
            {
                formatedShifts.Last().Duration = (shift.End - shift.Start).ToString();
            }
        }

        ConsoleTableBuilder
                .From(formatedShifts)
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
        DateTime shiftStart = GetShiftInput("\nEnter the shift's starting time (Format: HH:mm)\n");
        DateTime shiftEnd = GetShiftInput("\nEnter the shift's ending time (Format: HH:mm)\n");

        CreateShift(shiftStart, shiftEnd);
    }
}
