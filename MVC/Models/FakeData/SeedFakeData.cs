using DataAccess;
using Entity.Entity;
using Entity.Identity;
using Microsoft.EntityFrameworkCore;

namespace MVC.Models.FakeData;

public static class SeedFakeData
{
    public static void Seed(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<Context>();
            context.Database.Migrate();

            var loremIpsum500 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consequat auctor aliquam. Aliquam fermentum sit amet nisl et scelerisque. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam mattis quis est eget pretium. Sed nulla lorem, semper in sollicitudin sed, lobortis vitae purus. Aenean dolor dolor, blandit quis sagittis vel, ultricies eget dui. Quisque sollicitudin ligula eu ante posuere, at luctus mi suscipit. Nulla volutpat facilisis porttitor.";
            var rnd = new Random();

            //? MAKES 10000 CATEGORIES EVERYTIME PLEASE DONT LEAVE ON
            //for (int i = 0; i < 10000; i++)
            //{
            //	context.Categories.Add(
            //		new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Beyaz Eşya", Description = loremIpsum500 }
            //		);

            //}
            //context.BulkSaveChanges();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Giyim", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "İçecekler", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Teknoloji", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Gıda", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Mobilya", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Ev Aletleri", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Temizlik", Description = loremIpsum500 },
                    new CategoryModel { CreatedDate = DateTime.Now, State = 0, Name = "Beyaz Eşya", Description = loremIpsum500 }
                    );
            }
            context.BulkSaveChanges();
            if (!context.Dealers.Any())
            {
                context.Dealers.AddRange(
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Çamlıca", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Mecidiyeköy", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Ümraniye", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Sarıyer", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Kartal", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Pendik", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Beykoz", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Kadıköy", FullAdress = loremIpsum500 },
                new DealerModel { CreatedDate = DateTime.Now, State = 0, Name = "Taksim", FullAdress = loremIpsum500 }
                );
            }
            context.BulkSaveChanges();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Albeni", CategoryId = 1, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Metro", CategoryId = 2, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Gofret", CategoryId = 2, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Dido", CategoryId = 2, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Toblerone", CategoryId = 3, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Pepsi", CategoryId = 2, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "Sprite", CategoryId = 2, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) },
                    new ProductModel { CreatedDate = DateTime.Now, State = 0, ProductName = "TAI T929 ATAK 2 Atak Helikopteri", CategoryId = 4, Description = loremIpsum500, UsabilityGrade = rnd.Next(10), FunctionalityGrade = rnd.Next(10), InnovativeGrade = rnd.Next(10), LooksGrade = rnd.Next(10), PriceAdvantageGrade = rnd.Next(10) }
                    );
            }
            context.BulkSaveChanges();

            //if (!context.DealerStocks.Any())
            //{
            //	context.DealerStocks.AddRange(
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) },
            //		new DealerStocksModel { CreatedDate = DateTime.Now, State = 0, DealerId = context.Dealers.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), ProductId = context.Products.Where(x => x.State == 0).Select(x => x.Id).FirstOrDefault(), SupplierId = 0, SalesPrice = rnd.Next(100), MinimumAmount = rnd.Next(100), Amount = rnd.Next(100), Cost = rnd.Next(50) }
            //		);
            ////}

            context.BulkSaveChanges();
        }
    }
}