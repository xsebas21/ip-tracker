using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ip_tracker_library
{
    public class Engine
    {
        #region Events
        public event EventHandler IPChecked;
        public event EventHandler IPChanged;
        #endregion

        #region Private static members
        private string host = "http://icanhazip.com";
        private string lastIp = string.Empty;
        private int checksCounter = 0;
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the public IP address and compares it to the last one
        /// fetched. If it changed, it triggers the IP_Changed event.
        /// </summary>
        public void Check()
        {
            var response = new WebClient().DownloadString(host);
            var publicIp = response.Trim(Environment.NewLine.ToCharArray()).Trim();

            var args = new EngineEventArgs
            {
                Time = DateTime.Now,
                IP = publicIp,
                ChecksCounter = ++checksCounter,
                EventType = EngineEventType.IPChecked
            };

            OnIPChecked(args);

            if (publicIp != lastIp)
            {
                lastIp = publicIp;

                args.EventType = EngineEventType.IPChanged;
                OnIPChanged(args);
            }
        }
        #endregion

        #region Trigger Events
        protected virtual void OnIPChecked(EventArgs e)
        {
            EventHandler handler = IPChecked;
            handler?.Invoke(this, e);
        }

        protected virtual void OnIPChanged(EventArgs e)
        {
            EventHandler handler = IPChanged;
            handler?.Invoke(this, e);
        }
        #endregion

    }
}
