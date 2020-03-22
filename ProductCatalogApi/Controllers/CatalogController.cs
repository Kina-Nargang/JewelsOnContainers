using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalogApi.Data;
using ProductCatalogApi.Domain;
using ProductCatalogApi.ViewModels;

namespace ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        // get this config from appsetting.json (ExternalCatalogBaseUrl)
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context, IConfiguration config)
        {
            // get DB
            _context = context;
            // get config(local host)
            _config = config;
        }


        // this is old way to do route
        // http//:...../?k = xxx&v = ...
        // also can do [HttpGet{"pageIndex"}]
        // used [FromQuery] so no need to write [Route("[action]/{pageIndex}/{pageSize}")]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0, 
            [FromQuery]int pageSize = 6)
        {
            // talk to DB (_context) 
            // link query to give the total number of catalogitems records
            var itemsCount = await _context.CatalogItems.LongCountAsync();

            // link query: skip means how many records are going to be skipped on the page
            // take : how many records are going to be shown on the page
            // when user click next button to go to next page
            var items = await _context.CatalogItems
                                .Skip(pageIndex * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            items = ChangePictureUrl(items);


            // this VM get a list of catalogitems and pages info together
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };

            // return model when 200 OK
            return Ok(model);
        }

        private List<CatalogItem> ChangePictureUrl(List<CatalogItem> items)
        {
            items.ForEach(
                c => c.PictureUrl =
                    c.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
                        _config["ExternalCatalogBaseUrl"])
                    );

            return items;
        }
    }
}