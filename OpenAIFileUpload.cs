using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIFileUpload
{
    private readonly OpenAIClient _client;

    public OpenAIFileUpload(OpenAIClient client)
    {
        _client = client;
    }

    public async Task<string> UploadFileAsync(string filePath)
    {
        var fileContent = new MultipartFormDataContent();
        var fileBytes = File.ReadAllBytes(filePath);
        var byteArrayContent = new ByteArrayContent(fileBytes);
        byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        fileContent.Add(byteArrayContent, "file", Path.GetFileName(filePath));

        var response = await _client.PostRequestAsync("https://api.openai.com/v1/files", fileContent);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            return result.id;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
