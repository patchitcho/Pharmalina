using Pharmalina.Persistence;
using System;
using Xunit;

namespace Pharmalina.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public PharmalinaDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = PharmalinaContextFactory.Create();
        }

        public void Dispose()
        {
            PharmalinaContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
