using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Core.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public long Article { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Season { get; set; }
        public bool Gender { get; set; }
        public string Photo { get; set; }
        public IEnumerable<Sizes> SizesAvailable { get; set; }
    }
}