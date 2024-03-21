using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bwFinaleVeterinaria.Models
{
    public class HomeView
    {
        public IEnumerable<RescueAdmission> RescueAdmissions { get; set; }
        public Employee Employee { get; set; }
    }
}