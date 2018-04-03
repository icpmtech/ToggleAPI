using Common.Infrastructure;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
   public class Logger : ILoggerApi

    {
        public TypeLogger TypeLogger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public ILoggerRepository Repository => throw new NotImplementedException();

        public bool IsEnabledFor(Level level)
        {
            throw new NotImplementedException();
        }

        public void Log(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Log(LoggingEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
