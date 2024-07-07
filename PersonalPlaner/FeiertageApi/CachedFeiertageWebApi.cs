using PersonalPlaner.Abstractions.FeiertageApi;
using PersonalPlaner.Shared.FeiertageApi;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PersonalPlaner.FeiertageApi
{
    public class CachedFeiertageWebApi : IFeiertageWebApi
    {
        private readonly IMemoryCache cache;
        private readonly IFeiertageWebApi webApi;
        private readonly FeiertageRequestOptions? defaultOptions;

        public CachedFeiertageWebApi(IMemoryCache cache, IFeiertageWebApi webApi, FeiertageRequestOptions? defaultOptions = null)
        {
            this.cache = cache;
            this.webApi = webApi;
            this.defaultOptions = defaultOptions;
        }

        public async Task<FeiertageResponse> GetFeiertageAsync(DateTime year, FeiertageRequestOptions? options = null)
        {
            options = options ?? defaultOptions;
            var key = year.ToString("yyyy");
            if (cache.TryGetValue(key, out var feiertageResponse))
            {
                return (FeiertageResponse)feiertageResponse!;
            }
            else if (TryGetFromFileCache(key, out var feiertageResponse2))
            {
                return (FeiertageResponse)feiertageResponse2!;
            }
            else
            {
                var feiertage = await webApi.GetFeiertageAsync(year, options);
                cache.Set(key, feiertage);
                WriteToCache(key, feiertage);
                return feiertage;
            }
        }

        private bool TryGetFromFileCache(string key, out FeiertageResponse? feiertageResponse)
        {
            feiertageResponse = null;
            if (!Directory.Exists($"cache"))
            {
                return false;
            }
            var file = Path.Combine("cache", $"feiertage_{key}.json");
            if (!File.Exists(file))
            {
                return false;
            }
            feiertageResponse = JsonSerializer.Deserialize<FeiertageResponse>(file);
            if (feiertageResponse is null)
                return false;

            return true;
        }
        private void WriteToCache(string key, FeiertageResponse feiertageResponse)
        {
            if (!Directory.Exists($"cache"))
            {
                return;
            }
            var file = Path.Combine("cache", $"feiertage_{key}.json");
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<FeiertageResponse>(fs, feiertageResponse);
            }

        }
    }
}
