using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using BetterExtensions.Domain.Repository;
using TransactionsImporter.DataAccess.Abstractions.Repositories;
using TransactionsImporter.DataAccess.EF;
using TransactionsImporter.DataAccess.EF.Abstractions;
using TransactionsImporter.DataAccess.EF.Repositories;
using TransactionsImporter.DataAccess.EF.Seeder;
using TransactionsImporter.DataAccess.EF.Seeder.Abstractions;
using Module = Autofac.Module;

namespace TransactionsImporter.Api.IoC
{
    [ExcludeFromCodeCoverage]
    public class DataAccessModule : Module
    {
        protected override Assembly ThisAssembly => typeof(WriteDbContext).Assembly;

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DbSeeder>()
                .As<IDbSeeder>();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TransactionsRepository>()
                .As<ITransactionsRepository>()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(ReadRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerDependency();
        }
    }
}