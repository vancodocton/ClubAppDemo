using ClubApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Infrastructure.Fixtures
{
    public class TestPostDbContext : PostDbContext
    {
        public TestPostDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var testDbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ClubAppDb-testing;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(testDbConnectionString);
        }
    }
}
