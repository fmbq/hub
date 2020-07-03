using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace FMBQ.Hub.Tests
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Remove<T>(this IServiceCollection services)
        {
            var type = typeof(T);

            foreach (var descriptor in services.Where(d => d.ServiceType == type).ToList())
            {
                services.Remove(descriptor);
            }

            return services;
        }
    }
}
