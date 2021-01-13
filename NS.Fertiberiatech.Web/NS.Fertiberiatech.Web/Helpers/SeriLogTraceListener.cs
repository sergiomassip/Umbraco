using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Umbraco.Core.Logging;
using Umbraco.Core.Logging.Serilog;

namespace SMA.WebUI.Helpers
{
    public class SeriLogTraceListener : TraceListener
    {
        private readonly ILogger _log = SerilogLogger.CreateWithDefaultConfiguration();
        private readonly List<TraceSource> _traceSourceCollection;

        public SeriLogTraceListener () {
            // Set default values
            Name = "SeriLog Trace Listener";
            ActiveTraceLevel = TraceLevel.Verbose;

            // Create additional trace sources list
            _traceSourceCollection = new List<TraceSource>();

            // Add additional trace sources - .NET framework
            //TraceSources.Add(System.Diagnostics.

            // Subscribe to all trace sources
            foreach (TraceSource traceSource in _traceSourceCollection)
            {
                traceSource.Listeners.Add(this);
            }
        }

        /// <summary>
        /// Gets or sets the trace source collection.
        /// </summary>
        private List<TraceSource> TraceSourceCollection => _traceSourceCollection;

        /// <summary>
        /// Gets or sets the active trace type.
        /// </summary>
        public TraceLevel ActiveTraceLevel { get; set; }
        
        private const string ItemsSourceTimingIssueTrace = "ContentAlignment; DataItem=null;";

		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            // Call overload
            TraceEvent(eventCache, source, eventType, id, string.Format(CultureInfo.InvariantCulture, format, args));
        }

		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			// Should we ignore this line?
			if (message != null && message.Contains(ItemsSourceTimingIssueTrace)) return;

			// Check the type
			switch (eventType)
			{
				case TraceEventType.Error:
					if ((ActiveTraceLevel == TraceLevel.Error) ||
						 (ActiveTraceLevel == TraceLevel.Warning) ||
						 (ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						try
						{
							var lastIndexOf = eventCache.Callstack.LastIndexOf("System.Diagnostics.Trace.TraceError(String format, Object[] args)", StringComparison.Ordinal);
							if (lastIndexOf > -1)
							{
								_log.Error(message + eventCache.Callstack.Substring(lastIndexOf).Replace("System.Diagnostics.Trace.TraceError(String format, Object[] args)\r\n", ""));
							}
							else
							{
								_log.Error(message + eventCache.Callstack);
							}
						}
						catch (Exception)
						{
							_log.Error(message);
						}
					}
					break;

				case TraceEventType.Warning:
					if ((ActiveTraceLevel == TraceLevel.Warning) ||
						 (ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						try
						{
							var lastIndexOf = eventCache.Callstack.LastIndexOf("System.Diagnostics.Trace.TraceError(String format, Object[] args)", StringComparison.Ordinal);
							if (lastIndexOf > -1)
							{
								_log.Warn(message + eventCache.Callstack.Substring(lastIndexOf).Replace("System.Diagnostics.Trace.TraceError(String format, Object[] args)\r\n", ""));
							}
							else
							{
								_log.Warn(message + eventCache.Callstack);
							}
						}
						catch (Exception)
						{
                            _log.Warn(typeof(SeriLogTraceListener),message);
						}
					}
					break;

				case TraceEventType.Information:
					if ((ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						_log.Info(message);
					}
					break;

				// Everything else is verbose
				//case TraceEventType.Verbose:
				default:
					if (ActiveTraceLevel == TraceLevel.Verbose)
					{
						_log.Debug(message);
					}
					break;
			}
		}


		public override void Write(string message)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}