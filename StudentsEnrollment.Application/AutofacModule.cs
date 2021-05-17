using Autofac;
using MediatR.Pipeline;

namespace StudentsEnrollment.Application
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .Where(a => a.Name.EndsWith("Query"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .Where(a => a.Name.EndsWith("Command"))
                .AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).AsImplementedInterfaces();
        }
    }
}
