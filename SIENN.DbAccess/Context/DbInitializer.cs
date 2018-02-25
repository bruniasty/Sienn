using System;
using SIENN.DbAccess.Entities;
using Type = SIENN.DbAccess.Entities.Type;
using System.Linq;

namespace SIENN.DbAccess.Context
{
    public static class DbInitializer
    {

        public static void Initialize(StoreDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            // Look for any products
            if (dbContext.Products.Any())
            {
                return; // DB has been seeded
            }

            var categories = new[]
            {

                new Category {Code = "OUTS", Description = "Outdoors Shop"},
                new Category {Code = "CAMP", Description = "Camping Equipment"},
                new Category {Code = "MOUNTE", Description = "Mountaineering Equipment"},
                new Category {Code = "PERSA", Description = "Personal Accessories"},
                new Category {Code = "GOLFE", Description = "Golf Equipment"},
            };

            foreach (var category in categories)
            {
                dbContext.Categories.Add(category);
            }

            dbContext.SaveChanges();

            var types = new[]
            {
                new Type {Code = "WATCH", Description = "Watches"},
                new Type {Code = "EYEW", Description = "Eyewear"},
                new Type {Code = "IR", Description = "Irons"}
            };

            foreach (var type in types)
            {
                dbContext.Types.Add(type);
            }

            dbContext.SaveChanges();

            var units = new[]
            {
                new Unit {Code = "Q", Description = "Quantity"},
                new Unit {Code = "P", Description = "Package"},
                new Unit {Code = "S", Description = "Set"}
            };

            foreach (var unit in units)
            {
                dbContext.Units.Add(unit);
            }

            dbContext.SaveChanges();

            var products = new[]
            {
                new Product {Code = "MME", Description = "Mountain Man Extreme", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 588.42M, Type = types[0], Unit = units[0]},
                new Product {Code = "TX", Description = "TX", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 122.21M, Type = types[0], Unit = units[0]},
                new Product {Code = "KDK", Description = "Kodiak", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 122.21M, Type = types[0], Unit = units[0]},
                new Product {Code = "ZDK", Description = "Zodiak", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 670.34M, Type = types[0], Unit = units[0]},
                new Product {Code = "PS", Description = "Polar Sports", DeliveryDate = DateTime.Parse("2017-03-05"), IsAvailable = true, Price = 1212.32M, Type = types[1], Unit = units[0]},
                new Product {Code = "PI", Description = "Polar Ice", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 412.73M, Type = types[1], Unit = units[0]},
                new Product {Code = "DNT", Description = "Dante", DeliveryDate = DateTime.Parse("2018-02-25"), IsAvailable = true, Price = 222.22M, Type = types[1], Unit = units[0]},
                new Product {Code = "LHSI", Description = "Lady Hailstorm Steel Irons", DeliveryDate = DateTime.Parse("2015-12-04"), IsAvailable = true, Price = 12.19M, Type = types[2], Unit = units[0]},
                new Product {Code = "HTI", Description = "Hailstorm Titanium Irons", DeliveryDate = DateTime.Parse("2015-12-04"), IsAvailable = false, Price = 13.19M, Type = types[2], Unit = units[0]},
            };

            foreach (var product in products)
            {
                dbContext.Products.Add(product);
            }

            dbContext.SaveChanges();

            dbContext.AddRange(
                new ProductCategory {Product = products[0], Category = categories[0]},
                new ProductCategory {Product = products[0], Category = categories[4]},
                new ProductCategory {Product = products[1], Category = categories[0]},
                new ProductCategory {Product = products[2], Category = categories[0]},
                new ProductCategory {Product = products[3], Category = categories[0]},
                new ProductCategory {Product = products[4], Category = categories[1]},
                new ProductCategory {Product = products[5], Category = categories[1]},
                new ProductCategory {Product = products[6], Category = categories[2]},
                new ProductCategory {Product = products[7], Category = categories[3]},
                new ProductCategory {Product = products[7], Category = categories[4]},
                new ProductCategory {Product = products[8], Category = categories[3]}
            );
            dbContext.SaveChanges();
        }
    }
}