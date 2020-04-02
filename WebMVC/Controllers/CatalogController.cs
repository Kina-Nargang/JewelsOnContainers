using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    // controller name shoule match a folder under Views
    // create a folder with same name as this controller name under Views
    public class CatalogController : Controller
    {
        // we dont want to talk dicrectly with CatalogService class
        // so we setup to get it from startup class
        // we want to know who is implemented ICatalogService through ICatalogService
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        // under the Catalog folder there should be a page called Index
        // user will tell us the page number
        // int? means page could be null
        public async Task<IActionResult> Index(int? page)
        {
            var itemOnPage = 10;

            // _service is CatalogService class
            // page ?? 0 means if page is null then let page = 0
            // page ?? 0 => page == null ? 0 : page
            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemOnPage);
            var vm = new CatalogIndexViewModel
            {
                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemOnPage)
                }
            };

            // pass the data(vm) to the view
            return View(vm);
        }
    }
}