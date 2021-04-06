using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Services
{
    public interface ICustomLogger
    {
        string Log(string msg);
    }
    public class Logger1 : ICustomLogger
    {
        public string Log(string msg)
        {
            return $"{msg} Log from { GetType()}";
        }
    }

    public class Logger2 : ICustomLogger
    {
        public string Log(string msg)
        {
            return $"{msg} Log from { GetType()}";
        }
    }

    public class Logger3 : ICustomLogger
    {
        public string Log(string msg)
        {
            return $"{msg} Log from { GetType()}";
        }
    }

    public class Logger4 : ICustomLogger
    {
        public string Log(string msg)
        {
            return $"{msg} Log from { GetType()}";
        }
    }
}
