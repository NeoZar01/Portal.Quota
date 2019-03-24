using Microsoft.Practices.Unity;

namespace DoE.Quota.Repositories.Services.IoC
{
    using Contracts;
    using BusinessServices;

    using Data.Api;
    using Data.Inventories;

    using Repositories.BusinessServices;
    using Core.Repositories.Contracts;
    using Core.Repositories.Common;

    public static class RepositoryUnityContainer<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void BootstrapServices(IUnityContainer container)
        {
            container
                .RegisterType<IUnitofWork, UnitofWork>()
                .RegisterType<IInventoryRepository, InventoryRepository>()
                .RegisterType<IInventoryService, InventoryService>()
                .RegisterType<IShoppingCartService, ShoppingCartService>()
                .RegisterType<IUserServices, UserServices>();
                //.RegisterType<ISurveysRepository, SurveyService<Surveys>>()
                //.RegisterType<IGlobalCache<CacheVariable>, GlobalCache<CacheVariable>>();
        }
    }
}