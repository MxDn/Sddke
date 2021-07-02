using Agility.Api.Backlog.Application;

using Autofac;

namespace Agility.Api.Backlog.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Agility.Api.Backlog.Application
            //
            builder.RegisterAssemblyTypes(typeof(IResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
