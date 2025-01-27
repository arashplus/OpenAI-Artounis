using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Artounis;

internal class OpenAICache
{
    private Dictionary<string, string> _cache;

    public OpenAICache()
    {
        _cache = new Dictionary<string, string>();
    }

    public void AddToCache(string key, string response)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache.Add(key, response);
        }
    }

    public string GetFromCache(string key)
    {
        return _cache.ContainsKey(key) ? _cache[key] : null;
    }
}
