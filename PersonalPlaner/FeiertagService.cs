using PersonalPlaner.Abstractions.FeiertageApi;
using PersonalPlaner.Blazor.Models;
using PersonalPlaner.Shared.FeiertageApi;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlaner
{
    public class FeiertagService : IFeiertageService
    {
        private readonly IFeiertageWebApi feiertageWebApi;
        private readonly FeiertageRequestOptions? defaultOptions;

        public FeiertagService(IFeiertageWebApi feiertageWebApi, FeiertageRequestOptions? defaultOptions)
        {
            this.feiertageWebApi = feiertageWebApi;
            this.defaultOptions = defaultOptions;
        }

        public async Task<List<Appointment>> GetFeiertageAsync(DateTime year, FeiertageRequestOptions? options = null)
        {
            options = options ?? defaultOptions;

            var feiertage = await feiertageWebApi.GetFeiertageAsync(year, options);
            var appointments = new List<Appointment>();
            foreach (var feiertag in feiertage.Feiertage)
            {
                var date = DateTime.Parse(feiertag.Date);
                appointments.Add(new()
                {
                    Start = date,
                    End = date.AddDays(1).AddSeconds(-1),
                    Text = feiertag.Fname, 
                    Tag = "FT"
                });
            }
            return appointments;
        }
    }
}
