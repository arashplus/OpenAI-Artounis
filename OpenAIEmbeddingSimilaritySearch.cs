using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIEmbeddingSimilaritySearch
{
    private readonly OpenAIClient _client;

    public OpenAIEmbeddingSimilaritySearch(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> GetSimilarityAsync(string queryText, string documentText)
    {
        var requestData = new
        {
            model = "text-embedding-ada-002",
            input = new[] { queryText, documentText }
        };

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/embeddings", requestData);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            // Calculate cosine similarity between embeddings (use appropriate math here)
            return result.data[0].embedding;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
