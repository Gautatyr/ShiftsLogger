using static ShiftsLoggerUI.InterfaceApi;

namespace ShiftsLoggerUI;

public static class Helpers
{
    public static void DisplayError(string error)
    {
        Console.WriteLine($"\n|--->  {error}  <---|\n");
    }

    public static bool ShiftExists(int id)
    {
        var exists = false;

        if (GetShift(id) != null) exists = true;

        return exists;
    }
}
