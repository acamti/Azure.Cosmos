using System;
using Acamti.Azure.Cosmos.CosmosProxy;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace Acamti.Azure.Cosmos
{
    public static class CosmosClientDependencyInjection
    {
        public static IServiceCollection AddCosmosProxy(this IServiceCollection services,
                                                        Func<CosmosProxyConfiguration> configuration,
                                                        CosmosClientOptions clientOptions = null)
        {
            CosmosProxyConfiguration conf = configuration.Invoke();

            var client = new CosmosClient(conf.ConnectionString, clientOptions);
            var proxy = new CosmosProxy.CosmosProxy(client, conf.DatabaseId, conf.ContainerId);

            services.AddSingleton<ICosmosProxy>(proxy);

            return services;
        }
    }
}
