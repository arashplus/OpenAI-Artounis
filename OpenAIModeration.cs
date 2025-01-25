using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIModeration
{
    private readonly OpenAIClient _client;

    public OpenAIModeration(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> ModerationCheckAsync(string inputText)
    {
        var requestData = new
        {
            input = inputText
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/moderations", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
            return result.results[0].flagged.ToString();
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
