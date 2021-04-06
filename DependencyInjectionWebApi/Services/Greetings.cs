using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Services
{
    public interface IGreetings
    {
        public string greet(string name);
    }
    public class Greetings : IGreetings
    {
        public string greet(string name)
        {
            return $"Greetings for {name }";
        }
    }
}
