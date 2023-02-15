using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;


namespace Taku.CoinMarketTest.API
{
    public static class Extension
    {
        public static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface, string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);

            IEnumerable<Type> handlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (Type handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
