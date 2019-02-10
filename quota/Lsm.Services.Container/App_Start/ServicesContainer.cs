using Microsoft.Practices.Unity;

namespace DoE.Lsm.Web.Services.Repository.Local.IoC
{
    using Logger;
    using Validations;
    using ShoppingCart;
    using Lsm.Services.Api;
    using Lsm.ShoppingCart.Api;
    using Data.Repositories;
    using global::Lsm.Services.Component.Requisitions.Api;

    using global::Lsm.Services.Component.Requisitions.Services;
    using Validations.Api;
    using Component.Cache;
    using Lsm.Web.Repository.Services.Local.Api;
    using Lsm.Web.Repository.Services.Local;
    using Web.Session.Cache;

    public static class DependanciesContainer<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Package(IUnityContainer container)
        {
            container
                .RegisterType<ILogger, BaseLogger>()
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IValidationCallbackProvider, ValidationCallbackProvider>()
                .RegisterType<ISurveyRepository, SurveyInterfaceEntries>()
                .RegisterType<IShoppingCartRepository, ShoppingCartRepository>()
                .RegisterType<IServiceBootstrapper, ServicesBootstrapper>()
                .RegisterType<IShoppingCartService, ShoppingCartService>()
                .RegisterType<IGlobalCache, GlobalCache>();
        }
    }
}
