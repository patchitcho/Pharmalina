using System;
using Microsoft.EntityFrameworkCore;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence;


namespace Pharmalina.Application.Tests.Infrastructure
{
    class PharmalinaContextFactory
    {
        public static PharmalinaDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PharmalinaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PharmalinaDbContext(options);

            context.Database.EnsureCreated();

            context.Products.AddRange(new[] {
                new Product { Code = "ADAM", Reference = "Adam Cogan" },
                new Product { Code = "JASON", Reference = "Jason Taylor" },
                new Product { Code = "BREND", Reference = "Brendan Richards" },
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(PharmalinaDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
