using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Services
{
    public interface IServiceDescriptorService
    {
        string Message();
    }
    public class ServiceDescriptorService : IServiceDescriptorService
    {
        public string Message()
        {
            return "Hello from ServiceDescriptorService";
        }
    }
}
