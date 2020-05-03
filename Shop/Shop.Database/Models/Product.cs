using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Database.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id;
        public long Article;
        public string Category;
        public string Title;
        public string Label;
        public string Season;
        public bool Gender;
        public string Photo;
        public IEnumerable<Sizes> SizesAvailable;
    }
}