using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebStockLibrary.Model
{
    public class BasketItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Basket Basket { get; set; }
    }
}
