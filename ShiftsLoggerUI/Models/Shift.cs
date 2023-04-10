using System.Text.Json.Serialization;

namespace ShiftsLoggerUI.Models;

public record Shift(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("start")] DateTime Start,
    [property: JsonPropertyName("end")] DateTime End);

public class ShiftDTO
{
    public int Id;
    public DateTime Start;
    public DateTime End;
    
    public TimeSpan ShiftDuration()
    {
        return End - Start;
    }
}
