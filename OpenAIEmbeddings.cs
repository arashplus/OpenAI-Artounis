using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIEmbeddings
{
    private readonly OpenAIClient _client;

    public OpenAIEmbeddings(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> GetEmbeddingsAsync(string inputText)
    {
        var requestData = new
        {
            model = "text-embedding-ada-002",
            input = inputText
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/embeddings", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent) ?? new { };
            return result.data[0].embedding;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
