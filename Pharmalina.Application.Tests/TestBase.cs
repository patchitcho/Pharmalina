using Microsoft.EntityFrameworkCore;
using System;
using Pharmalina.Persistence;


namespace Pharmalina.Application.Tests
{
    class TestBase
    {
        public PharmalinaDbContext GetDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<PharmalinaDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new PharmalinaDbContext(builder.Options);
            if (useSqlLite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
