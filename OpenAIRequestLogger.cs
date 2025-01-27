using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAIRequestLogger
{
    private readonly string _logFilePath;

    public OpenAIRequestLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void LogRequest(string requestContent)
    {
        File.AppendAllText(_logFilePath, $"Request: {requestContent}\n");
    }

    public void LogResponse(string responseContent)
    {
        File.AppendAllText(_logFilePath, $"Response: {responseContent}\n");
    }
}
