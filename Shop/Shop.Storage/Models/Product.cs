using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Storage.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public long Article { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Season { get; set; }
        public bool Gender { get; set; }
        public List<string> Photos { get; set; }
        public List<Sizes> SizesAvailable { get; set; }
        public double? Price { get; set; }
    }
}