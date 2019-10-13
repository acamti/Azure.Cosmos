using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace AcamTI.Azure.Cosmos.DependencyInjection
{
    public static class CosmoClientDependencyInjection
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, string endpoint, string key)
        {
            var client = new CosmosClient(endpoint, key);

            services.AddSingleton(client);

            return services;
        }
    }
}
