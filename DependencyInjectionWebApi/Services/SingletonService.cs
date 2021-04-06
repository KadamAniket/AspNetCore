using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Services
{
    public interface ISingletonService
    {   
        Guid GetGuid();
    }
    public class SingletonService : ISingletonService
    {
        private readonly Guid _guid;
        public SingletonService(IGuidService service)
        {
            _guid = service.GetGuid();
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
