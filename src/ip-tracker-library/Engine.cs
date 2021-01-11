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
        public event EventHandler<EngineCheckEventArgs> IPChecked;
        public event EventHandler<EngineCheckEventArgs> IPChanged;
        public event EventHandler<EngineErrorEventArgs> CheckError;
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
            var publicIp = "0.0.0.0";

            try
            {
                var response = new WebClient().DownloadString(host);
                publicIp = response.Trim(Environment.NewLine.ToCharArray()).Trim();
            }
            catch (Exception ex)
            {
                var errorArgs = new EngineErrorEventArgs
                {
                    Time = DateTime.Now,
                    EventType = EngineEventType.CheckError,
                    Exception = ex
                };

                OnCheckError(errorArgs);
            }

            var args = new EngineCheckEventArgs
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
        protected virtual void OnIPChecked(EngineCheckEventArgs e)
        {
            var handler = IPChecked;
            handler?.Invoke(this, e);
        }

        protected virtual void OnIPChanged(EngineCheckEventArgs e)
        {
            var handler = IPChanged;
            handler?.Invoke(this, e);
        }

        protected virtual void OnCheckError(EngineErrorEventArgs e)
        {
            var handler = CheckError;
            handler?.Invoke(this, e);
        }
        #endregion

    }
}
