using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtticEntertainment.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public virtual ICollection<Activity> RoomActivities { get; set; }
        [JsonIgnore]
        public virtual Event RoomEvent { get; set; }
    }
}
