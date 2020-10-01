using Autofac;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Application.Readers;

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
        }
    }
}