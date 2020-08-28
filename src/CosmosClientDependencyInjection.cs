using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acamti.Azure.Cosmos
{
    public static class CosmosClientDependencyInjection
    {
        public static IServiceCollection AddCosmosProxy(this IServiceCollection services,
            Action<CosmosProxyConfiguration, IConfiguration> configureOptions,
            CosmosClientOptions clientOptions = null)
        {
            services
                .AddTransient<ICosmosProxy, CosmosProxy>()
                .AddSingleton(new CustomCosmosClientOptions { CosmosClientOptions = clientOptions })
                .AddOptions<CosmosProxyConfiguration>()
                .Configure(configureOptions);

            return services;
        }
    }
}
