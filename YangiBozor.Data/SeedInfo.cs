using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YangiBozor.Data.DbContexts;
using YangiBozor.Domain.Entities;

namespace NBU.Data
{
    public class SeedInfo
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<YangiBozorDbContext>();
                //Look for any products.

                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                context.Users.AddRange(
                    new User
                    {
                        ProfilePhotoUrl = "https://tvline.com/wp-content/uploads/2020/09/the-boys-season-2-homelander.jpg",
                        FirstName = "Homelander",
                        LastName = "Supe",
                        Phone = "1234567890",
                        UserName = "Home",
                        Password = "1234567890"
                    },
                   new User
                   {
                       ProfilePhotoUrl = "https://tvline.com/wp-content/uploads/2020/09/the-boys-season-2-homelander.jpg",
                       FirstName = "Azim",
                       LastName = "Supe",
                       Phone = "123456890",
                       UserName = "Azimchik",
                       Password = "123456790"
                   },
                    new User
                    {
                        ProfilePhotoUrl = "https://tvline.com/wp-content/uploads/2020/09/the-boys-season-2-homelander.jpg",
                        FirstName = "Komron",
                        LastName = "Supe",
                        Phone = "12345670",
                        UserName = "Komron",
                        Password = "1234w"
                    }
                );
                if (!context.Products.Any())
                {
                    context.Products.AddRange
                    (
                        new Product
                        {
                            ProductPhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTG8blzQSE_RYjdNt32KgKuaXloPBM7MrI08w&usqp=CAU",
                            Name = "Iphone 14 pro max",
                            Description = "The best phone in the world",
                            Type = YangiBozor.Domain.Enums.CategoryType.Electronics,
                            Price = 1400
                        },
                        new Product
                        {
                            ProductPhotoUrl = "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/61-MT8AQAPL._SX466_.jpg ",
                            Name = "Iphone SE 3",
                            Description = "Old design but with new tech",
                            Type = YangiBozor.Domain.Enums.CategoryType.Electronics,
                            Price = 429
                        }
                    );
                }

                context.SaveChanges();
            }
        }

    }
}
