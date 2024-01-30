using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudShop.ProductAPI.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public required string Name { get; set; }
        public required string Category { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
