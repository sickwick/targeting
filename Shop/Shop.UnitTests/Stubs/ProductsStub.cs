using System.Collections.Generic;
using Shop.Api.Data.Models;

namespace Shop.UnitTests.Stubs
{
    public class ProductsStub
    {
        public List<ProductDto> Products = new List<ProductDto> 
        {
            new ProductDto()
            {
                Id = "e23e23e23rf2f2f232xx3rc2xz",
                Article = 12345, Category = "Limited", Label = "Nike",
                Title = "Air force 1 'Cactus Jack'",
                About = "Air Jordan 1 Low — одна из самых легендарных моделей в истории, которая никогда не выходит из моды. Эта версия SE дополняет классический дизайн новыми насыщенными цветами и элементами отделки.",
                Photo = new List<string>()
                {
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/tfm4djwrkhlq5wxgwypq/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/milyrog9rqkmkw4j0lgg/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/gupow9zhq2lwbyziiouu/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/ieumpbss2wifjxi5i9f9/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/leplgo42nzkdufz0vvor/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/leplgo42nzkdufz0vvor/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg",
                    "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/a2bvpg12f3fm58cgv7lm/кроссовки-air-jordan-legacy-312-low-mpV0mH.jpg"
                },
                SizesAvailable = new List<SizesDto>
                {
                    new SizesDto()
                    {
                        Size = 13.5,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 4}

                    }
                },
                Price =  8250
            },
            new ProductDto()
            {
                Id = "e23e23e23rf2f2f232xxew3123",
                Article = 12454, Category = "Classic", Label = "Nike",
                Title = "Air force 1",
                Photo = new List<string>()
                {
                    "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5,q_80/ga0g0giyocrvslw07rhc/кроссовки-air-force-1-07-6jXPDp.jpg",
                },
                SizesAvailable = new List<SizesDto>()
                {
                    new SizesDto()
                    {
                        Size = 11,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 28}
                    },
                    new SizesDto()
                    {
                        Size = 12,
                        Availability = new AvailabilityDto {IsAvailable = false, QuantityInStock = 0}
                    },
                    new SizesDto()
                    {
                        Size = 13,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 2}
                    },
                }
            },
            new ProductDto
            {
                Id = "e23e23e23rf2f2f232xx3rc2xz",
                Article = 12345, Category = "Limited", Label = "Nike",
                Title = "Air force 1 'Cactus Jack'",
                Photo = new List<string>()
                {
                    "https://c.static-nike.com/a/images/t_prod_ss/w_480,c_limit,q_auto,f_auto/yhx8mbkb2yfqkcuqg8lc/air-force-1-cactus-jack-release-date.jpg"
                },
                SizesAvailable = new List<SizesDto>()
                {
                    new SizesDto()
                    {
                        Size = 14,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 4}
                    }
                }
            },
            new ProductDto
            {
                Id = "e23e23e23rf2f2f232xxew3123",
                Article = 12454, Category = "Classic", Label = "Nike",
                Title = "Air force 1",
                Photo = new List<string>()
                {
                    "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5,q_80/ga0g0giyocrvslw07rhc/кроссовки-air-force-1-07-6jXPDp.jpg"
                },
                SizesAvailable = new List<SizesDto>()
                {
                    new SizesDto()
                    {
                        Size = 11,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 28}
                    },
                    new SizesDto()
                    {
                        Size = 12,
                        Availability = new AvailabilityDto {IsAvailable = false, QuantityInStock = 0}
                    },
                    new SizesDto()
                    {
                        Size = 13,
                        Availability = new AvailabilityDto {IsAvailable = true, QuantityInStock = 2}
                    },
                }
            }
        };
    }
}