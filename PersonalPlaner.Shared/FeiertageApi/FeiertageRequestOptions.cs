using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlaner.Shared.FeiertageApi
{
    public class FeiertageRequestOptions
    {
        public string? Bundesland { get; set; }
        public bool AugsburgIncluded { get; set; }
        public bool KatholischIncluded { get; set; }

    }
}
