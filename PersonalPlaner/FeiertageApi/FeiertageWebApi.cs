using PersonalPlaner.Abstractions.FeiertageApi;
using PersonalPlaner.Shared.FeiertageApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PersonalPlaner.FeiertageApi
{
    public class FeiertageWebApi : IFeiertageWebApi
    {
        private readonly HttpClient httpClient;
        private readonly FeiertageRequestOptions? defaultOptions;

        public FeiertageWebApi(HttpClient httpClient, FeiertageRequestOptions? defaultOptions = null)
        {
            this.httpClient = httpClient;
            this.defaultOptions = defaultOptions;
        }

        public async Task<FeiertageResponse> GetFeiertageAsync(DateTime year, FeiertageRequestOptions? options = null)
        {
            options = options ?? defaultOptions;
            string api = $"https://get.api-feiertage.de/?years={year.ToString("yyyy")}";

            var response = await httpClient.GetFromJsonAsync<FeiertageResponse>(api);
            if (response == null)
            {
                throw new Exception($"Keine Antwort erhalten von: {api}");
            }
            //Feiertage nach Optionen filtern
            response.Feiertage = response.Feiertage.Where(x => FilterByOptions(x, options)).ToArray();
            return response;
        }

        private bool FilterByOptions(Feiertag x, FeiertageRequestOptions? options)
        {
            bool include = true;
            if (options == null) return true;
            else
            {
                if (!options.KatholischIncluded && x.Katholisch is not null)
                {
                    include = false;
                }
                if (!options.AugsburgIncluded && x.Augsburg is not null)
                {
                    include = false;
                }
                if (options.Bundesland is string bundesland)
                {
                    include = FilterByBundesland(x, bundesland);
                }
            }
            return include;
        }

        private bool FilterByBundesland(Feiertag x, string bundesland)
        {
            bool include = true;
            if (bundesland == "bw" && x.Bw != "1") { include = false; }
            if (bundesland == "by" && x.By != "1") { include = false; }
            if (bundesland == "be" && x.Be != "1") { include = false; }
            if (bundesland == "bb" && x.Bb != "1") { include = false; }
            if (bundesland == "hb" && x.Hb != "1") { include = false; }
            if (bundesland == "hh" && x.Hh != "1") { include = false; }
            if (bundesland == "he" && x.He != "1") { include = false; }
            if (bundesland == "mv" && x.Mv != "1") { include = false; }
            if (bundesland == "ni" && x.Ni != "1") { include = false; }
            if (bundesland == "nw" && x.Nw != "1") { include = false; }
            if (bundesland == "rp" && x.Rp != "1") { include = false; }
            if (bundesland == "sl" && x.Sl != "1") { include = false; }
            if (bundesland == "sn" && x.Sn != "1") { include = false; }
            if (bundesland == "st" && x.St != "1") { include = false; }
            if (bundesland == "sh" && x.Sh != "1") { include = false; }
            if (bundesland == "th" && x.Th != "1") { include = false; }

            return include;
        }
    }
}
