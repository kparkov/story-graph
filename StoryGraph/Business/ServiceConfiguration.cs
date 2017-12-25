using System;
using KVP.StoryGraph.Utility;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace KVP.StoryGraph.Business
{
    public class ServiceConfiguration
    {
        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(ServiceConfiguration));
                    _.WithDefaultConventions();
                    _.AddAllTypesOf<IService>();
                    //_.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                });

                //config.For(typeof(IValidator<>)).Add(typeof(DefaultValidator<>));
                //config.For(typeof(ILeaderboard<>)).Use(typeof(Leaderboard<>));
                //config.For<IUnitOfWork>().Use(_ => new UnitOfWork(3)).ContainerScoped();

                //Populate the container using the service collection

                config.For<TestService>().Add<TestService>().Transient();
                config.For(typeof(ModelMapper<,>)).Add(typeof(ModelMapper<,>));
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
