using static ShiftsLoggerUI.InterfaceApi;

namespace ShiftsLoggerUI;

public static class Helpers
{
    public static void DisplayError(string error)
    {
        string arrowLeft = "\n|---> ";
        string arrowRight = " <---|\n";
        Console.WriteLine($"{arrowLeft} {error} {arrowRight}");
    }

    public static bool ShiftExists(int id)
    {
        bool exists = false;

        if (GetShift(id) != null) exists = true;

        return exists;
    }
}
