using System.Collections.Generic;
using Shop.Database.Stubs.Models;

namespace Shop.Database.Stubs
{
    public class ProductsStub
    {
        public List<ProductModel> Products = new List<ProductModel>
        {
            new ProductModel
            {
                Id = "e23e23e23rf2f2f232xx3rc2xz",
                Article = 12345, Category = "Limited", Label = "Nike",
                Title = "Air force 1 'Cactus Jack'",
                Photo =
                    "https://c.static-nike.com/a/images/t_prod_ss/w_480,c_limit,q_auto,f_auto/yhx8mbkb2yfqkcuqg8lc/air-force-1-cactus-jack-release-date.jpg",
                SizesAvailable = new List<SizesModel>
                {
                    new SizesModel(){
                        Size = 13.5,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 4}
                        
                    }
                }
            },
            new ProductModel
            {
                Id = "e23e23e23rf2f2f232xxew3123",
                Article = 12454, Category = "Classic", Label = "Nike",
                Title = "Air force 1",
                Photo =
                    "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5,q_80/ga0g0giyocrvslw07rhc/кроссовки-air-force-1-07-6jXPDp.jpg",
                SizesAvailable = new List<SizesModel>()
                {
                    new SizesModel()
                    {
                        Size = 11,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 28}
                    },
                    new SizesModel()
                    {
                        Size = 12,
                        Availability = new AvailabilityModel {IsAvailable = false, QuantityInStock = 0}
                    },
                    new SizesModel()
                    {
                        Size = 13,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 2}
                    },
                }
            },
            new ProductModel
            {
                Id = "e23e23e23rf2f2f232xx3rc2xz",
                Article = 12345, Category = "Limited", Label = "Nike",
                Title = "Air force 1 'Cactus Jack'",
                Photo =
                    "https://c.static-nike.com/a/images/t_prod_ss/w_480,c_limit,q_auto,f_auto/yhx8mbkb2yfqkcuqg8lc/air-force-1-cactus-jack-release-date.jpg",
                SizesAvailable = new List<SizesModel>()
                {
                    new SizesModel()
                    {
                        Size = 14,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 4}
                    }
                }
            },
            new ProductModel
            {
                Id = "e23e23e23rf2f2f232xxew3123",
                Article = 12454, Category = "Classic", Label = "Nike",
                Title = "Air force 1",
                Photo =
                    "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5,q_80/ga0g0giyocrvslw07rhc/кроссовки-air-force-1-07-6jXPDp.jpg",
                SizesAvailable = new List<SizesModel>()
                {
                    new SizesModel()
                    {
                        Size = 11,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 28}
                    },
                    new SizesModel()
                    {
                        Size = 12,
                        Availability = new AvailabilityModel {IsAvailable = false, QuantityInStock = 0}
                    },
                    new SizesModel()
                    {
                        Size = 13,
                        Availability = new AvailabilityModel {IsAvailable = true, QuantityInStock = 2}
                    },
                }
            }
        };
    }
}