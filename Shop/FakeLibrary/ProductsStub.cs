using System.Collections.Generic;
using FakeLibrary.CopiedModels;

namespace FakeLibrary
{
    public class ProductsStub
    {
        public List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = "e23e23e23rf2f2f232xx3rc2xz",
                Article = 12345, Category = "Limited", Label = "Nike",
                Title = "Air force 1 'Cactus Jack'",
                Photo =
                    "https://avatars.mds.yandex.net/get-zen_doc/1711766/pub_5dc9ca45cb3bd340e4f13b5b_5dc9cacef91fc7585e530758/scale_1200",
                SizesAvailable = new List<Sizes>
                {
                    new Sizes() {XL = new Availability {IsAvailable = true, QuantityInStock = 4}}
                }
            },
            new Product
            {
                Id = "e23e23e23rf2f2f232xxew3123",
                Article = 12454, Category = "Classic", Label = "Nike",
                Title = "Air force 1",
                Photo = "https://www.slamdunk.su/thumbs/5c1dd941a60c1315122-001-PHCFH001-2000.jpeg", SizesAvailable =
                    new List<Sizes>
                    {
                        new Sizes() {M = new Availability {IsAvailable = true, QuantityInStock = 28}},
                        new Sizes() {L = new Availability() {IsAvailable = false, QuantityInStock = 0}},
                        new Sizes() {S = new Availability() {IsAvailable = true, QuantityInStock = 120}}
                    }
            },
        };
    }
}