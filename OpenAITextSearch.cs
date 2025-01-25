using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAITextSearch
{
    private readonly OpenAIClient _client;

    public OpenAITextSearch(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> PerformSearchAsync(string query, string[] documents)
    {
        var requestData = new
        {
            model = "davinci",
            query = query,
            documents = documents
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/search", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
            return result.data[0].text;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
