using System.Web.Mvc;
using Ninject.Web.Mvc;
using OnlineShop.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineShop.Web.Telerik.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineShop.Web.Telerik.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineShop.Web.Telerik.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using OnlineShop.Web.Telerik.Models;
    using OnlineShop.Domain;
    

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

                kernel.Bind(
                    o => o.FromAssemblyContaining<ProductoRepository>()
                        .SelectAllClasses()
                        .WhichAreNotGeneric()
                        .InheritedFrom(typeof(IRepository<>))
                        .BindAllInterfaces()
                    );
                kernel.Bind<ShopContext>().ToSelf().InRequestScope();

                kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
                kernel.Bind<IUserStore<ApplicationUser>>()
                    .To<UserStore<ApplicationUser>>()
                    .InRequestScope()
                    .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
                kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InRequestScope();

                kernel.Bind<IAuthenticationManager>().ToMethod(
                    m => HttpContext.Current.GetOwinContext().Authentication
                    ).InRequestScope();

                kernel.Bind<IRoleStore<IdentityRole, string>>()
                    .To<RoleStore<IdentityRole>>()
                    .InRequestScope()
                    .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
                kernel.Bind<RoleManager<IdentityRole>>().ToSelf().InRequestScope();



                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

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
        }        
    }
}
