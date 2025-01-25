using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIFineTuning
{
    private readonly OpenAIClient _client;

    public OpenAIFineTuning(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> FineTuneModelAsync(string trainingFileId)
    {
        var requestData = new
        {
            model = "davinci",
            training_file = trainingFileId
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/fine-tunes", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
            return result.id;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
