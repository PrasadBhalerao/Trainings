using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Queues;

namespace HPlusSportsAPI.Services
{
    /// <summary>
    /// Manages writing orders to an Azure Queue
    /// </summary>
    public class AzureQueueService : IQueueService
    {
        IConfiguration config;

        public AzureQueueService(IConfiguration configuration)
        {
            config = configuration;
        }

        public async Task SendMessageAsync<T>(T item)
        {
            
        }
        
    }
}
