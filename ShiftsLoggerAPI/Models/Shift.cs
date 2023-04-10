namespace ShiftsLoggerAPI.Models;

public class Shift
{
    public int Id { get; set; }
    DateTime start { get; set; }
    DateTime end { get; set; }

    public TimeSpan duration()
    {
        return end - start;
    }
}
