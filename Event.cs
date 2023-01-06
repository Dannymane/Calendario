using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// class Event is a simple data transfer object, that is why all properties are public
namespace Calendario.Images
{
    public class Event
    {
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
