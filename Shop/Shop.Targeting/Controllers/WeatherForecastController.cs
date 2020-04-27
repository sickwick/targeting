using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Database;
using Shop.Database.MongoDB;

namespace Shop.Targeting.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private DatabaseBase _provider;
        public WeatherForecastController()
        {
            _provider = new MainDatabase();
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            _provider = new MongoDatabase(_provider, new MongoDatabaseContext(
                Environment.GetEnvironmentVariable("DB_NAME"),"User"));
            return Ok(await _provider.GetDatabaseList<UserModel>());
        }
    }
}