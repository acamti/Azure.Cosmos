﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Acamti.Azure.Cosmos.CosmosProxy
{
    public interface ICosmosProxy
    {
        Task<ItemResponse<TDocument>> CreateDocumentAsync<TDocument>(
            TDocument document,
            PartitionKey partitionKey
        ) where TDocument : class;

        Task<ItemResponse<TDocument>> ReplaceDocumentAsync<TDocument>(
            TDocument document,
            string documentId,
            PartitionKey partitionKey
        ) where TDocument : class;

        Task<ItemResponse<TDocument>> UpsertDocumentAsync<TDocument>(
            TDocument document,
            PartitionKey partitionKey
        ) where TDocument : class;

        Task<TDocument> GetDocumentAsync<TDocument>(
            Func<IQueryable<TDocument>,
                IQueryable<TDocument>> conditions,
            QueryRequestOptions requestOptions = null
        ) where TDocument : class;

        IAsyncEnumerable<TDocument> GetDocumentsAsync<TDocument>(
            Func<IQueryable<TDocument>,
                IQueryable<TDocument>> conditions,
            QueryRequestOptions requestOptions = null
        ) where TDocument : class;
    }
}