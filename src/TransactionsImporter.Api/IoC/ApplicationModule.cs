using Autofac;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Application.Readers;
using TransactionsImporter.Domain;
using TransactionsImporter.Domain.Abstractions;

namespace TransactionsImporter.Api.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<TransactionsReader>()
                .As<ITransactionsReader>()
                .InstancePerDependency();

            builder
                .RegisterType<TransactionsMapper>()
                .As<ITransactionsMapper>()
                .InstancePerDependency();
        }
    }
}