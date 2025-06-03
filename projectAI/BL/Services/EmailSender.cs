using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Api;

public class EmailSender : IEmailSender
{
    private readonly HttpClient _httpClient;

    private readonly string _googleScriptUrl = "https://script.google.com/macros/s/AKfycbxTYDLsP4ZwqP-I5XSSD_9oxDgBw9laDlZCN-QXDlA7pns0Q6Qw9riaO3zZMfmYyN4c/exec";

    public EmailSender(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendOrderEmailAsync(string email, string name, string movieName, string orderLink, int viewerCount, int viewCount, decimal totalPrice)
    {
        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", email),
            new KeyValuePair<string, string>("name", name),
            new KeyValuePair<string, string>("movieName", movieName),
            new KeyValuePair<string, string>("orderLink", orderLink),
            new KeyValuePair<string, string>("viewerCount", viewerCount.ToString()),
            new KeyValuePair<string, string>("viewCount", viewCount.ToString()),
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
