using System.Configuration;
using System.Linq;
using application.Client.Models;
using MongoDB.Driver;

namespace application.Client
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/data"] = parameters =>
            {
                var connectionstring =
    ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
                var url = new MongoUrl(connectionstring);
                var client = new MongoClient(url);
                var server = client.GetServer();
                var database = server.GetDatabase(url.DatabaseName);

                var collection = database.GetCollection<Thingy>("Thingies");

                // insert object
                collection.Insert(new Thingy { Name = "foo" });

                // fetch all objects
                var thingies = collection.FindAll();
                return thingies.ToList().ToString();
            };
        }
    }
}