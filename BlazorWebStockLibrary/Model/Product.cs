using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebStockLibrary.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImgUrl { get; set; }
        public Category Category { get; set; }
    }
}
