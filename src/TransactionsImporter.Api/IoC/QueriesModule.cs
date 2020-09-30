using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using MediatR;
using TransactionsImporter.Queries.Abstractions;

namespace TransactionsImporter.Api.IoC
{
    [ExcludeFromCodeCoverage]
    public class QueriesModule : Autofac.Module
    {
        protected override Assembly ThisAssembly => typeof(QueryHandlerBase<,>).Assembly;

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
        }
    }
}