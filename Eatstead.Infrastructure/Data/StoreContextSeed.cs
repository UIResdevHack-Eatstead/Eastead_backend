using Eatstead.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Valuegate.Infrastructure.Data;

namespace Eatstead.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.Menus.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    var menusData = File.ReadAllText("../Eatstead.Infrastructure/Data/SeedData/Menu.json");
                    var menus = JsonSerializer.Deserialize<List<Menu>>(menusData);

                    foreach (var item in menus)
                    {
                        var menu = new Menu
                        {
                            Cafeteria = item.Cafeteria,
                            CafeteriaId = item.CafeteriaId,
                            Description = item.Description,
                            Id = item.Id,
                            Name = item.Name,
                            PictureUrl = item.PictureUrl,
                            Price = item.Price,
                        };
                        context.Menus.Add(menu);
                    }

                    ///   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");

                    await context.SaveChangesAsync();

                    //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");

                    transaction.Commit();
                }


                if (!context.Cafeterias.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    var typesData = File.ReadAllText("../Eatstead.Infrastructure/Data/SeedData/Cafeteria.json");
                    var types = JsonSerializer.Deserialize<List<Cafeteria>>(typesData);

                    foreach (var item in types)
                    {
                        context.Cafeterias.Add(item);
                    }

                  

                    await context.SaveChangesAsync();

                    //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");

                    transaction.Commit();
                }


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }

        }
    
}
