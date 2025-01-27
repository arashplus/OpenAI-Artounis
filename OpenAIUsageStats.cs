using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIUsageStats
{
    public int RequestCount { get; private set; }
    public int TokenUsage { get; private set; }

    public void IncrementRequestCount()
    {
        RequestCount++;
    }

    public void AddTokenUsage(int tokens)
    {
        TokenUsage += tokens;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Request Count: {RequestCount}");
        Console.WriteLine($"Total Token Usage: {TokenUsage}");
    }
}
