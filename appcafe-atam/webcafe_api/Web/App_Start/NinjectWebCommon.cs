
using System.Linq;
using System.Reflection;
using VD.Data.Entity.MF;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using VD.Data.Base;
    using VD.Data;
    using VD.Data.Repository;
    using VD.Data.IRepository;
    using VD.Data.Repository.Logging;
    using VD.Data.IRepository.Logging;
 
  
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
                RegisterCores(kernel);
                RegisterRepositories(kernel);
                RegisterServices(kernel);
                RegisterLogging(kernel);
               
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

        private static void RegisterCores(IKernel kernel)
        {
            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

        
        }
   
        private static void RegisterRepositories(IKernel kernel)
        {
            kernel.Bind<ISettingRepository>().To<SettingRepository>();
            kernel.Bind<IConfigRepository>().To<ConfigRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ILangRepository>().To<LangRepository>();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
          

         

            kernel.Bind<ICounterRepository>().To<CounterRepository>();
            kernel.Bind<ISliderRepository>().To<SliderRepository>();
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            //
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();
            kernel.Bind<IImgTmpRepository>().To<ImgTmpRepository>();
            //
            kernel.Bind<IDonHangRepository>().To<DonHangRepository>();

            //web api
            kernel.Bind<IProductCatRepository>().To<ProductCatRepository>();

            kernel.Bind<IQuanRepository>().To<QuanRepository>();
            //kernel.Bind<IBanRepository>().To<BanRepository>();
        }
        private static void RegisterServices(IKernel kernel)
        {
            
         
        }
        private static void RegisterLogging(IKernel kernel)
        {
            kernel.Bind<ILogRepository>().To<LogRepository>();
            kernel.Bind<ILogTypeRepository>().To<LogTypeRepository>();
            kernel.Bind<ILogExceptionRepository>().To<LogExceptionRepository>();
        }
    }
}
