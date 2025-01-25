using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAICompletion
{
    private readonly OpenAIClient _client;

    public OpenAICompletion(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> GetCompletionAsync(string prompt, string model = "text-davinci-003", int maxTokens = 100)
    {
        var requestData = new
        {
            model = model,
            prompt = prompt,
            max_tokens = maxTokens
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/completions", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
            return result.choices[0].text;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
