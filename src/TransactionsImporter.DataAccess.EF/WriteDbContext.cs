using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TransactionsImporter.Common.Configurations;
using TransactionsImporter.DataAccess.Abstractions.Entities;

namespace TransactionsImporter.DataAccess.EF
{
    public sealed class WriteDbContext : DbContext
    {
        private static readonly Type[] EnumerationTypes =
        {
            typeof(Currency)
        };

        private readonly IHostEnvironment _environment;
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _dbConnectionString;

        public WriteDbContext(
            IHostEnvironment environment, 
            ILoggerFactory loggerFactory,
            IOptions<ConnectionStrings> connectionStringsOptions)
        {
            _environment = environment;
            _loggerFactory = loggerFactory;
            _dbConnectionString = connectionStringsOptions.Value.TransactionsImporterDb;
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Currency> Currencies { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (_environment != null && (_environment.IsDevelopment() || _environment.IsStaging()))
                builder
                    .UseLoggerFactory(_loggerFactory)
                    .EnableSensitiveDataLogging();

            builder
                .UseSqlServer(
                    _dbConnectionString,
                    x => x.MigrationsAssembly(typeof(WriteDbContext).Assembly.FullName))
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(WriteDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries()
                .Where(x => EnumerationTypes.Contains(x.Entity.GetType()))
                .ToList()
                .ForEach(entity => entity.State = EntityState.Unchanged);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}