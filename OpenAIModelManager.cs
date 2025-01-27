using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIModelManager
{
    public string ModelName { get; set; }
    public string ModelVersion { get; set; }

    public OpenAIModelManager(string modelName, string modelVersion)
    {
        ModelName = modelName;
        ModelVersion = modelVersion;
    }

    public void DisplayModelInfo()
    {
        Console.WriteLine($"Model Name: {ModelName}");
        Console.WriteLine($"Model Version: {ModelVersion}");
    }
}
