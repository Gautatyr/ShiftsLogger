namespace ShiftsLoggerAPI.Models;

public class Shift
{
    public int Id { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }

    public TimeSpan duration()
    {
        return end - start;
    }
}
