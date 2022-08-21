using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Utvikleroppgave_AD_NTP.DAL
{
    public class InitDB
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ProductContext>();

            if (context != null)
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var product1 = new Products
                {
                    Name = "Adhesive",
                    Unit = "kg",
                    Amount = 0,
                    Priority = false,
                };

                var product2 = new Products
                {
                    Name = "Ink",
                    Unit = "Liter",
                    Amount = 0,
                    Priority = false,
                };

                context.Add(product1);
                context.Add(product2);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Null database context");
            }
        }
    }
}
