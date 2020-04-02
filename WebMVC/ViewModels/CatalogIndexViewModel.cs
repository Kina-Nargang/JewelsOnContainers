using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<CatalogItem> CatalogItems { get; set; }

        // int? means this int value can be null
        // value types usually have default value cant be null
        // if we do int? then it wil accept null value
        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }

    }
}
