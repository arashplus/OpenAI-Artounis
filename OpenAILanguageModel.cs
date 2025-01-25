using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAILanguageModel
{
    private readonly OpenAIClient _client;

    public OpenAILanguageModel(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> GetCompletionForLanguageAsync(string prompt, string language = "en", string model = "text-davinci-003")
    {
        var requestData = new
        {
            model = model,
            prompt = prompt,
            max_tokens = 100,
            language = language
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
