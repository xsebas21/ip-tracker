using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ip_tracker_library
{
    public enum EngineEventType
    {
        IPChecked,
        IPChanged,
        CheckError
    }

    public abstract class EngineEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public EngineEventType EventType { get; set; }
    }

    public class EngineCheckEventArgs : EngineEventArgs
    {
        public string IP { get; set; }
        public int ChecksCounter { get; set; }
    }

    public class EngineErrorEventArgs : EngineEventArgs
    {
        public Exception Exception { get; set; }
    }
}
