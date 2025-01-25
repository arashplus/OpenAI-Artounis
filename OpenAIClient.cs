using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIClient
{
    private readonly OpenAIConfig _config;
    private readonly HttpClient _httpClient;

    public OpenAIClient(OpenAIConfig config)
    {
        _config = config ?? throw new OpenAIException("Config cannot be null");
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.ApiKey}");
    }

    // Common request handling for OpenAI
    public async Task<HttpResponseMessage> PostRequestAsync(string endpoint, object data)
    {
        try
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_config.Endpoint}/{endpoint}", content);
            return response;
        }
        catch (Exception ex)
        {
            throw new OpenAIException("Error during API request", ex);
        }
    }
}
