using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUri;
        private readonly IHttpClient _client;
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
            // get client from startup 
            // we dont want to bind this service with CustomHttpClient which is implemented IHttpClient
            // so setup in start up file to see which class is implementing the interface(IHttpClient)
            // through interface to get which class has this interface
            // in the future it doesnt matter if we delete the class and create a new class
            // client is CustomHttpClient class that is from start up file
            _client = client;
        }
        public async Task<Catalog> GetCatalogItemsAsync(int page, int size)
        {
            // get api path
            // $"{baseUri}items?pageIndex={page}&pageSize={take}"
            var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_baseUri, page, size);

            // _client is CustomHttpClient class
            // pass uri to get data
            var dataString = await _client.GetStringAsync(catalogItemsUri);

            // Deserialize data into Catalog type
            // return this data to catalog controller
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }
    }
}
