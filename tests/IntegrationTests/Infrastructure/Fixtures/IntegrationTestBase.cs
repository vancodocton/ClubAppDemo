using ClubApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public abstract class IntegrationTestBase
    {
        protected TestPostDbContext dbContext;

        public IntegrationTestBase()
        {
            dbContext = (TestPostDbContext)new TestPostDbContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
