using PersonalPlaner.App.Models;
using PersonalPlaner.Shared.FeiertageApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlaner.Abstractions.FeiertageApi
{
    public interface IFeiertageService
    {
        Task<List<Appointment>> GetFeiertageAsync(DateTime year, FeiertageRequestOptions? options = null);

    }
}
