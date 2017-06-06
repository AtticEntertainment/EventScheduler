using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtticEntertainment.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public bool ActivityAllDay { get; set; }
        public DateTime ActivityStart { get; set; }
        public DateTime ActivityEnd { get; set; }
        public int ActivityScope { get; set; }

        [JsonIgnore]
        public virtual Room ActivityRoom { get; set; }
    }
}
