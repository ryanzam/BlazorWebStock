using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebStockLibrary.Model
{
    public class Basket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
    }
}
