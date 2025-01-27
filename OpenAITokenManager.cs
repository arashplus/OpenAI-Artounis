using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAITokenManager
{
    private string _apiToken;

    public OpenAITokenManager(string token)
    {
        _apiToken = token;
    }

    public void SetToken(string token)
    {
        _apiToken = token;
    }

    public string GetToken()
    {
        return _apiToken;
    }

    public bool IsTokenValid()
    {
        // Add your validation logic
        return !string.IsNullOrEmpty(_apiToken);
    }
}
