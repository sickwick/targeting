using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shop.Database;
using Shop.Database.Interfaces;
using Shop.Database.MongoDB;

namespace Shop.Targeting.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private DatabaseBase _provider;
        private IMemoryCache _memoryCache;
        public WeatherForecastController(IProductDataProvider productDataProvider, IMemoryCache memoryCache)
        {
            _provider = new MainDatabase();
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            _provider = new MongoDatabase(null, new MongoDatabaseContext(
                Environment.GetEnvironmentVariable("DB_NAME"),"User"));
            // var k = ProductListHolder.GetInstance().ProductList;
            var k = new ProductDataProvider(_memoryCache);
            return Ok(k.GetProducts());
        }
    }
}