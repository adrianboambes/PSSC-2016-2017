using University.DataLayer.Implementation;
using System.Linq;
using System.Data.Entity;
using Commands;
using DbQueryExecutors;
using Interfaces.Commands;
using Interfaces.Queries;
using Ninject.Extensions.Conventions;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UniversityLocal.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(UniversityLocal.App_Start.NinjectWebCommon), "Stop")]

namespace UniversityLocal.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IQueryDispatcher>().To<QueryDispatcher>();
                kernel.Bind<ICommandDispatcher>().To<CommandDispatcher>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x => x
                        .FromAssembliesMatching("Interfaces.dll", "UniversityLocal.dll")
                        .SelectAllClasses()
                        .BindDefaultInterface());

            kernel.Bind(x => x
                        .FromAssembliesMatching("Commands.dll", "University.DataLayer.Implementation.dll")
                        .SelectAllClasses().InheritedFrom(typeof(IRepository))
                        .BindDefaultInterface());
            kernel.Bind(x => x
                        .FromAssembliesMatching("DbQueryExecutors.dll", "University.DataLayer.Implementation.dll")
                        .SelectAllClasses().InheritedFrom(typeof(IRepository))
                        .BindDefaultInterface());

            kernel.Bind(x => x
                        .FromAssembliesMatching("Commands.dll")
                        .SelectAllClasses().InheritedFrom(typeof(ICommandHandler<>))
                        .BindAllInterfaces());

            kernel.Bind(x => x
                        .FromAssembliesMatching("DbQueryExecutors.dll")
                        .SelectAllClasses().InheritedFrom(typeof(IQueryHandler<,>))
                        .BindAllInterfaces());

        }        
    }
}
