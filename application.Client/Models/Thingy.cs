using MongoDB.Bson;

namespace application.Client.Models
{
    public class Thingy
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}