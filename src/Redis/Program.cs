// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;
Thread.Sleep(10000);
Console.WriteLine("Console_App started!");
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect
    (
           new ConfigurationOptions
           {
               Password = Environment.GetEnvironmentVariable("RedisPassword"),
               EndPoints = { Environment.GetEnvironmentVariable("ConnectionString") }
           }
    );

var db = redis.GetDatabase();
db.StringSetAsync("foo", "Hi, i'm foo").Wait();
var foo = db.StringGetAsync("foo").Result;
Console.WriteLine(foo.ToString());
Console.WriteLine("Console_App finished!");