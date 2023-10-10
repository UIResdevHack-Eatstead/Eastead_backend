using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuegate.Common.Interfaces
{
    public interface ILoggerManager
    {
        void LogError(string logEvent, object logData);
        void LogInfo(string logEvent, object logData);
    }
}
