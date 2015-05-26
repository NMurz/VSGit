using EasyFood.Data;
using EasyFood.Data.Repositories.GenericResository;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(easyFood.Admin2.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(easyFood.Admin2.App_Start.NinjectWebCommon), "Stop")]

namespace easyFood.Admin2.App_Start
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
            kernel.Bind(typeof(IGenericRepository<cuisine>)).To(typeof(GenericRepository<cuisine>));
            kernel.Bind(typeof(IGenericRepository<dish>)).To(typeof(GenericRepository<dish>));
            kernel.Bind(typeof(IGenericRepository<order>)).To(typeof(GenericRepository<order>));
            kernel.Bind(typeof(IGenericRepository<order_items>)).To(typeof(GenericRepository<order_items>));
            kernel.Bind(typeof(IGenericRepository<dish_restaurant>)).To(typeof(GenericRepository<dish_restaurant>));
            kernel.Bind(typeof(IGenericRepository<restaurant>)).To(typeof(GenericRepository<restaurant>));
            kernel.Bind(typeof(IGenericRepository<review>)).To(typeof(GenericRepository<review>));

            kernel.Bind(typeof(IGenericRepository<AspNetUser>)).To(typeof(GenericRepository<AspNetUser>));
        }        
    }
}
