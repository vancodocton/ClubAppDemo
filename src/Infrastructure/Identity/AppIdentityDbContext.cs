using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ClubApp.Infrastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>,
        IPersistedGrantDbContext
    {
        public DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;

        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; } = null!;

        public DbSet<Key> Keys { get; set; } = null!;

        private readonly IOptions<OperationalStoreOptions> operationalStoreOptions;

        public AppIdentityDbContext(
            DbContextOptions<AppIdentityDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
            ) : base(options)
        {
            this.operationalStoreOptions = operationalStoreOptions;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigurePersistedGrantContext(operationalStoreOptions.Value);
        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

    }
}