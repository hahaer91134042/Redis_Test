using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis_Test.Models;
using Redis_Test.Models.DB;

namespace Redis_Test.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private MyRedis redis;
        private TestDbContext db;
        public TestController(MyRedis _r,TestDbContext _db)
        {
            redis = _r;
            db = _db;
        }

        [HttpPost]
        [Route("Test")]
        public object Test()
        {
            return new
            {
                msg = "Success Hill",
                value=redis.GetString("runoob"),
                db=db.Products
            };
        }

        [HttpGet]
        [Route("GetInitMag")]
        public object GetInitMsg()
        {
            var now= DateTime.Now;
            return new
            {
                now,
                msg = redis.GetString("InitMsg"),
            };
        }

        [HttpPost]
        [Route("AddItem")]
        public object AddItem([FromForm] int num)
        {
            var initNum=(from g in db.Products
                         orderby g.Id descending
                         select g).First().Id;

            for (int i = 0; i < num; i++)
            {
                var j=initNum + i + 1;
                db.Products.Add(new Product
                {
                    Name = "商品_" + (j),
                    Time = DateTime.Now.AddSeconds(j),
                });
            }
            db.SaveChanges();
            return new
            {
                msg = "Success",
            };
        }


    }
}
