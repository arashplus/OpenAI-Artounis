using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIStreamProcessing
{
    private readonly HttpClient _httpClient;

    public OpenAIStreamProcessing(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task StreamCompletionAsync(string endpoint, string prompt, CancellationToken cancellationToken)
    {
        var content = new StringContent($"{{ \"prompt\": \"{prompt}\" }}");

        // Corrected: Use SendAsync instead of PostAsync
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = content
        };

        // Specify the HttpCompletionOption and pass the cancellationToken in the SendAsync method
        var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            using (var reader = new System.IO.StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            throw new Exception($"Error streaming data: {response.StatusCode}");
        }
    }
}
