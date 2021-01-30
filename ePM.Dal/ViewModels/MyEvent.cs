using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.ViewModels
{
    public  class MyEvent
    {
        public int event_id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string trainer { get; set; }
        public System.DateTime event_start { get; set; }
        public System.DateTime event_end { get; set; }
        public string backgroundColor { get; set; }
    }
}
