using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIBatchProcessing
{
    private readonly OpenAIClient _client;

    public OpenAIBatchProcessing(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<List<string>> ProcessBatchRequestsAsync(List<string> prompts, string model = "text-davinci-003")
    {
        var responses = new List<string>();

        foreach (var prompt in prompts)
        {
            var requestData = new
            {
                model = model,
                prompt = prompt,
                max_tokens = 100
            };

            var response = await _client.PostRequestAsync("https://api.openai.com/v1/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
                responses.Add(result.choices[0].text);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        return responses;
    }
}
