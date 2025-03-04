using StackExchange.Redis;

namespace Redis_Test.Models
{
    public class MyRedis
    {
        private IDatabase _db;
        public MyRedis()
        {
            //"127.0.0.1:6379,password=yourpassword"
            var redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            _db=redis.GetDatabase();
        }


        public string GetString(string k)
        {
            var s= _db.StringGet(k);
            return s.IsNull?"":s.ToString();
        }

        public void SetString(string k, string v)
        {
            _db.StringSet(k, v);
        }
    }
}
