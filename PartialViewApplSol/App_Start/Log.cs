using System.Diagnostics;

namespace PartialViewApplSol.App_Start
{
    public class Log
    {
        static TraceSource source = new TraceSource("WebAppLog");
        
        public static void Message(TraceEventType traceEventType, string message)
        {
            short id;
            switch (traceEventType)
            {
                case TraceEventType.Information:
                    id = 3;
                    break;
                case TraceEventType.Verbose:
                    id = 4;
                    break;
                default:
                    id = -1;
                    break;
            }
            source.TraceEvent(traceEventType, id, message);
        }

        public static void Error(TraceEventType traceEventType, object obj)
        {
            short id;
            switch (traceEventType)
            {
                case TraceEventType.Critical:
                    id = 0;
                    break;
                case TraceEventType.Error:
                    id = 1;
                    break;
                case TraceEventType.Warning:
                    id = 2;
                    break;
                default:
                    id = -1;
                    break;
            }
            source.TraceData(traceEventType, id, obj);
            source.Flush();
        }

    }
}