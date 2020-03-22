using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.ViewModels
{
    // Generic TEntity 
    public class PaginatedItemsViewModel<TEntity>
        // reference type only
        // if we set up struct here instead of class it would be any value types
        where TEntity : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
