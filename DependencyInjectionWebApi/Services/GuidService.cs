using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Services
{
    public interface IGuidService
    {
        Guid GetGuid();
    }
    public class GuidService : IGuidService
    {
        private readonly Guid _guid;
        public GuidService()
        {
            _guid = Guid.NewGuid();
            Console.WriteLine(_guid.ToString());
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
