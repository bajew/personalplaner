using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlaner.App.Models
{
    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
    }
}
