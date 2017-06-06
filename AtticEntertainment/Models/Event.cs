using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtticEntertainment.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public virtual ICollection<Room> EventRooms { get; set; }
    }
}
