using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Acamti.Azure.Cosmos.CosmosProxy
{
    public class CosmosProxy : ICosmosProxy

    {
        private readonly Container _container;

        internal CosmosProxy(CosmosClient client, string databaseId, string containerId)
        {
            _container = client.GetContainer(databaseId, containerId);
        }

        public Task<ItemResponse<TDocument>> CreateDocumentAsync<TDocument>(TDocument document, PartitionKey partitionKey)
            where TDocument : class =>
            _container.CreateItemAsync(
                document,
                partitionKey
            );

        public Task<ItemResponse<TDocument>> ReplaceDocumentAsync<TDocument>(TDocument document, string documentId, PartitionKey partitionKey)
            where TDocument : class =>
            _container.ReplaceItemAsync(
                document,
                documentId,
                partitionKey
            );

        public Task<ItemResponse<TDocument>> UpsertDocumentAsync<TDocument>(TDocument document, PartitionKey partitionKey)
            where TDocument : class =>
            _container.UpsertItemAsync(
                document,
                partitionKey
            );

        public async Task<TDocument> GetDocumentAsync<TDocument>(
            Func<IQueryable<TDocument>,
                IQueryable<TDocument>> conditionBuilder,
            QueryRequestOptions requestOptions = null
        ) where TDocument : class
        {
            FeedIterator<TDocument> feedIterator = conditionBuilder(
                _container.GetItemLinqQueryable<TDocument>(requestOptions: requestOptions)
            ).ToFeedIterator();

            while (feedIterator.HasMoreResults)
            {
                foreach (TDocument document in await feedIterator.ReadNextAsync())
                {
                    return document;
                }
            }

            return null;
        }

        public async Task<IEnumerable<TDocument>> GetDocumentsAsync<TDocument>(
            Func<IQueryable<TDocument>,
                IQueryable<TDocument>> conditionBuilder,
            QueryRequestOptions requestOptions = null
        ) where TDocument : class
        {
            var docList = new List<TDocument>();

            FeedIterator<TDocument> feedIterator = conditionBuilder(
                _container.GetItemLinqQueryable<TDocument>(requestOptions: requestOptions)
            ).ToFeedIterator();

            while (feedIterator.HasMoreResults)
            {
                docList.AddRange(await feedIterator.ReadNextAsync());
            }

            return docList;
        }

        public async IAsyncEnumerable<TDocument> GetDocumentsIteratorAsync<TDocument>(
            Func<IQueryable<TDocument>,
                IQueryable<TDocument>> conditionBuilder,
            QueryRequestOptions requestOptions = null
        ) where TDocument : class
        {
            FeedIterator<TDocument> feedIterator = conditionBuilder(
                _container.GetItemLinqQueryable<TDocument>(requestOptions: requestOptions)
            ).ToFeedIterator();

            while (feedIterator.HasMoreResults)
            {
                foreach (TDocument doc in await feedIterator.ReadNextAsync())
                {
                    yield return doc;
                }
            }
        }
    }
}
