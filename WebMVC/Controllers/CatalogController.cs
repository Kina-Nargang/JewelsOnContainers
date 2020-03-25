using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.services;

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
        public async Task<IActionResult> Index(int page)
        {
            var itemOnPage = 10;

            // _service is CatalogService class
            var catalog = await _service.GetCatalogItemsAsync(page, itemOnPage);

            // pass the data(catalog) to the view
            return View(catalog);
        }
    }
}