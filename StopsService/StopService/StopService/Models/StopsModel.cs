using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopService.Models
{
    public class StopRoutes
    {
        public int StopName { get; set; }
        public string StopTime { get; set; }
        public DateTime StopTimeDT { get; set; }
        public int route { get; set; }
    }
}
