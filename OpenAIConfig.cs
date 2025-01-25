using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

public class OpenAIConfig
{
    public required string ApiKey { get; set; }
    public string DefaultModel { get; set; } = "text-davinci-003"; // Default model
    public string Endpoint { get; set; } = "https://api.openai.com/v1"; // Default API
}
