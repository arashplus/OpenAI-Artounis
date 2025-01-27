using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIFinetuningHelper
{
    public void PrepareFineTuningData(List<(string prompt, string completion)> trainingData, string outputPath)
    {
        try
        {
            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var (prompt, completion) in trainingData)
                {
                    // Create a dictionary with prompt and completion
                    var fineTuneData = new
                    {
                        prompt = prompt,
                        completion = completion
                    };

                    // Serialize to JSON format and write to the output stream
                    var json = JsonConvert.SerializeObject(fineTuneData);
                    writer.WriteLine(json); // Write each line as a JSONL entry
                }
            }

            Console.WriteLine("Training data has been prepared and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error preparing training data: {ex.Message}");
        }
    }
}
