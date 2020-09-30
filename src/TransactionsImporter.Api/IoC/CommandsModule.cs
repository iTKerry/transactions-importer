using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using MediatR;
using TransactionsImporter.Commands.Abstractions;

namespace TransactionsImporter.Api.IoC
{
    [ExcludeFromCodeCoverage]
    public class CommandsModule : Autofac.Module
    {
        protected override Assembly ThisAssembly => typeof(CommandHandlerBase<>).Assembly;

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
        }
    }
}