using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ip_tracker_library
{
    public class EngineEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public string IP { get; set; }
        public int ChecksCounter { get; set; }
    }
}
