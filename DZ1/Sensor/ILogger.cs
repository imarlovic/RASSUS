using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    public interface ILogger
    {
        void Log(string text);
        void LogEvent(LogEventType eventType, string text);
    }

    public enum LogEventType
    {
        Neighbour,
        MeasuredData,
        Registration,
        Error,
        RequestReceived,
        RequestSent
    }
}
