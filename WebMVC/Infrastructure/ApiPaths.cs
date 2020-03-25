using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    // return a Uri that tells you where is the endpoint(apis) located
    public class ApiPaths
    {
        public static class Catalog
        {
            // baseUri is the evnironment variable from configuration
            public static string GetAllCatalogItems(string baseUri, int page, int take)
            {
                return $"{baseUri}items?pageIndex={page}&pageSize={take}";
            }
        }
      
        public static class Basket
        {

        }
    }
}
