using System.Collections.Generic;

namespace Shop.Database.Stubs.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        public long Article { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Season { get; set; }
        public bool Gender { get; set; }
        public string Photo { get; set; }
        public IEnumerable<SizesModel> SizesAvailable { get; set; }
    }
}