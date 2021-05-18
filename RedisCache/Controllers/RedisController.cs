using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private IEasyCachingProvider _provider;
        private IEasyCachingProviderFactory _providerFactory;

        public RedisController(IEasyCachingProviderFactory providerFactory)
        {
            this._providerFactory = providerFactory;
            this._provider = this._providerFactory.GetCachingProvider("myredis");
        }


        [HttpGet("set")]
        public IActionResult Set(MyClass myClass)
        {
            myClass.Date = DateTime.Now;
            this._provider.Set("MyKey", myClass, TimeSpan.FromMinutes(30));

            return Ok();
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = this._provider.Get<MyClass>("MyKey");

            return Ok(result);
        }
    }
}
