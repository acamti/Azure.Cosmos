using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Acamti.Azure.Cosmos.CosmosProxy
{
    public interface ICosmosProxy
    {
        Task<ItemResponse<TDocument>> CreateDocumentAsync<TDocument>(TDocument document,
                                                                     PartitionKey partitionKey,
                                                                     ItemRequestOptions requestOptions = null,
                                                                     CancellationToken cancellationToken = default)
            where TDocument : class;

        Task<ItemResponse<TDocument>> ReplaceDocumentAsync<TDocument>(TDocument document,
                                                                      string documentId,
                                                                      PartitionKey partitionKey,
                                                                      ItemRequestOptions requestOptions = null,
                                                                      CancellationToken cancellationToken = default)
            where TDocument : class;

        Task<ItemResponse<TDocument>> UpsertDocumentAsync<TDocument>(TDocument document,
                                                                     PartitionKey partitionKey,
                                                                     ItemRequestOptions requestOptions = null,
                                                                     CancellationToken cancellationToken = default)
            where TDocument : class;

        Task<TDocument> GetDocumentAsync<TDocument>(string id,
                                                    PartitionKey partitionKey,
                                                    ItemRequestOptions requestOptions = null)
            where TDocument : class;

        IAsyncEnumerable<TDocument> GetDocumentsIteratorAsync<TDocument>(Func<IQueryable<TDocument>,
                                                                             IQueryable<TDocument>> conditionBuilder = null,
                                                                         QueryRequestOptions requestOptions = null)
            where TDocument : class;

        Task<IEnumerable<TDocument>> GetDocumentsAsync<TDocument>(Func<IQueryable<TDocument>,
                                                                      IQueryable<TDocument>> conditionBuilder = null,
                                                                  QueryRequestOptions requestOptions = null)
            where TDocument : class;
    }
}
