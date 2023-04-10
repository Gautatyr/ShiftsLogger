﻿using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using ShiftsLoggerUI.Models;


namespace ShiftsLoggerUI;

public static class InterfaceApi
{
    public static async Task<List<Shift>> GetShifts()
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string api_url = $"https://localhost:7060/api/Shifts";

        var shifts = await ProcessQueryAsync(client, api_url);

        async Task<List<Shift>> ProcessQueryAsync(HttpClient client, string api_url)
        {
            await using Stream stream =
                await client.GetStreamAsync(api_url);
            var shifts =
                await JsonSerializer.DeserializeAsync<List<Shift>>(stream);

            return shifts;
        }

        return shifts;
    }

    public static async Task<Shift> GetShift(int id)
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string api_url = $"https://localhost:7060/api/Shifts/{id}";

        var shift = await ProcessQueryAsync(client, api_url);

        async Task<Shift> ProcessQueryAsync(HttpClient client, string api_url)
        {
            await using Stream stream =
                await client.GetStreamAsync(api_url);
            var shift =
                await JsonSerializer.DeserializeAsync<Shift>(stream);

            return shift;
        }

        return shift;
    }
}