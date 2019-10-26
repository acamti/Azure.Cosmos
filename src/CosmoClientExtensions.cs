using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace AcamTI.Azure.Cosmos.DependencyInjection
{
    public static class CosmoClientDependencyInjection
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, string endpoint, string key, CosmosClientOptions clientOptions = null)
        {
            var client = new CosmosClient(endpoint, key, clientOptions);

            services.AddSingleton(client);

            return services;
        }

        public static IServiceCollection AddCosmosDb(this IServiceCollection services, string connString, CosmosClientOptions clientOptions = null)
        {
            var client = new CosmosClient(connString, clientOptions);

            services.AddSingleton(client);

            return services;
        }
    }
}
