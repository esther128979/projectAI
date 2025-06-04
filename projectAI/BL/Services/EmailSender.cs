using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Api;
using BL.Models;
using System.Text.Json;

public class EmailSender : IEmailSender
{
    private readonly HttpClient _httpClient;

    private readonly string _googleScriptUrl = "https://script.google.com/macros/s/AKfycbyDCdAAkIImeMDYtET0imtGYTMEPqyQKlCaaAjiG95etcQxI8v5HHVQo8tEo4_SzdHn/exec";

    public EmailSender(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendOrderEmailAsync(string email, string name, List<OrderItemEmailDto> orderItems, decimal totalPrice)
    {
        // המר רשימת פריטים ל-JSON
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string orderItemsJson = JsonSerializer.Serialize(orderItems, options);

        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", email),
            new KeyValuePair<string, string>("name", name),
            new KeyValuePair<string, string>("orderItems", orderItemsJson),
            new KeyValuePair<string, string>("totalPrice", totalPrice.ToString("F2"))
        });

        try
        {
            var response = await _httpClient.PostAsync(_googleScriptUrl, formContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Email sent successfully: " + result);
                return true;
            }
            else
            {
                Console.WriteLine("Error sending email: " + result);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception sending email: " + ex.Message);
            return false;
        }
    }
}
