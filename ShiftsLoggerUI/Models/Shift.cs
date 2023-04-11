﻿using System.Text.Json.Serialization;

namespace ShiftsLoggerUI.Models;

public record Shift(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("start")] DateTime Start,
    [property: JsonPropertyName("end")] DateTime End);

public class ShiftDTO
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public TimeSpan ShiftDuration()
    {
        return End - Start;
    }
}

public class ShiftDTODisplay
{
    public int Id { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public string Duration { get; set; }
}
