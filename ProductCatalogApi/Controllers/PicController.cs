using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public PicController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("{id}")]
        public IActionResult GetImage(int id)
        {
            var webRoot = _env.WebRootPath;
            // get path where the pics are
            var path = Path.Combine($"{webRoot}/Pics/", $"Ring{id}.jpg");
            // pass this path to file
            // here using System.IO.File because base class:ControllerBase 
            // has file method too so make it different from system io file  
            // we need to change pictures into bytes and return pictures bytes
            // so we dont have to return paths which would not work
            var buffer = System.IO.File.ReadAllBytes(path);

            // this file is from base class ControllerBase
            // tell File that pass buffer and this is images jpeg 
            return File(buffer, "image/jpeg");
        }
    }
}