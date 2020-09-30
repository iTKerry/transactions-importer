﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TransactionsImporter.Common.Configurations;
using TransactionsImporter.DataAccess.Abstractions.Views;

namespace TransactionsImporter.DataAccess.EF
{
    public class ReadDbContext : DbContext
    {
        private readonly IHostEnvironment _environment;
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _dbConnectionString;

        public ReadDbContext(
            IHostEnvironment environment,
            ILoggerFactory loggerFactory,
            IOptions<ConnectionStrings> connectionStringsOptions)
        {
            _environment = environment;
            _loggerFactory = loggerFactory;
            _dbConnectionString = connectionStringsOptions.Value.TransactionsImporterDb;
        }

        public DbSet<TransactionView> TransactionViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (_environment != null && (_environment.IsDevelopment() || _environment.IsStaging()))
                builder
                    .UseLoggerFactory(_loggerFactory)
                    .EnableSensitiveDataLogging();

            builder
                .UseSqlServer(
                    _dbConnectionString,
                    x => x.MigrationsAssembly(typeof(ReadDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ReadDbContext).Assembly);
        }
    }
}
