using System;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Tests.Infrastructure
{
    class CommandTestBase
    {
        protected readonly PharmalinaDbContext _context;

        public CommandTestBase()
        {
            _context = PharmalinaContextFactory.Create();
        }

        public void Dispose()
        {
            PharmalinaContextFactory.Destroy(_context);
        }
    }
}
