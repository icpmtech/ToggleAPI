
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
   public interface ILoggerApi:ILogger
    {
         TypeLogger TypeLogger { get; set; }
    }
}
