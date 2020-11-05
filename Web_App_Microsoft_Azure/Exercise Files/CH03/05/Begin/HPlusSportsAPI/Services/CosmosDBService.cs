using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSportsAPI.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace HPlusSportsAPI.Services
{
    /// <summary>
    /// Responsible for saving and loading products to Cosmos DB
    /// </summary>
    public class CosmosDBService : IDocumentDBService
    {
        DocumentClient docClient;

        string dbName, collectionName; 
        Uri productCollectionUri;

        public CosmosDBService(IOptions<CosmosDBServiceOptions> options, DocumentClient client)
        {
            dbName = options.Value.DBName;
            collectionName = options.Value.DBCollection;

            docClient = client;
            productCollectionUri = UriFactory.CreateDocumentCollectionUri(dbName, collectionName);

        }

        public async Task<T> AddProductAsync<T>(T product)
        {
            var dbResponse = await docClient.CreateDocumentAsync(
                productCollectionUri, product);

            return (dynamic)dbResponse.Resource;
        }

        public async Task<ProductBase> GetProductAsync(string id)
        {
            //placeholder
            return null;
        }

        public async Task<List<ProductBase>> GetProductsAsync()
        {
            return new List<ProductBase>();
        }

        public async Task AddImageToProductAsync(string id, string imageUri)
        {
            
        }
    }
}
