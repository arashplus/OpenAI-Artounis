using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIExceptionHandler
{
    private readonly string _logFilePath;
    private readonly string _monitoringSystemEndpoint;

    public OpenAIExceptionHandler(string logFilePath, string monitoringSystemEndpoint)
    {
        _logFilePath = logFilePath;
        _monitoringSystemEndpoint = monitoringSystemEndpoint;
    }

    public async Task HandleExceptionAsync(Exception ex)
    {
        // Prepare the exception details in JSON format
        var exceptionDetails = new
        {
            TimeStamp = DateTime.UtcNow,
            ExceptionMessage = ex.Message,
            StackTrace = ex.StackTrace,
            InnerException = ex.InnerException?.Message,
            Source = ex.Source,
            TargetSite = ex.TargetSite?.ToString(),
            Type = ex.GetType().ToString()
        };

        // Log to file
        await LogToFileAsync(exceptionDetails);

        // Log to monitoring system
        await LogToMonitoringSystemAsync(exceptionDetails);
    }

    // Log exception details to a local file as JSON
    private async Task LogToFileAsync(object exceptionDetails)
    {
        try
        {
            using (var writer = new StreamWriter(_logFilePath, append: true))
            {
                string jsonLog = JsonConvert.SerializeObject(exceptionDetails);
                await writer.WriteLineAsync(jsonLog);
            }

            Console.WriteLine("Exception logged to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to log exception to file: {ex.Message}");
        }
    }

    // Log exception details to a monitoring system (e.g., Sentry, Loggly)
    private async Task LogToMonitoringSystemAsync(object exceptionDetails)
    {
        try
        {
            // Assuming monitoring system accepts JSON via POST request
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(exceptionDetails), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_monitoringSystemEndpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Exception logged to monitoring system.");
                }
                else
                {
                    Console.WriteLine($"Failed to log exception to monitoring system: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to log exception to monitoring system: {ex.Message}");
        }
    }
}
