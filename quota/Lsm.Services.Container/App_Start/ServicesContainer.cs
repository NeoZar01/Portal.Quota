using Microsoft.Practices.Unity;

namespace DoE.Lsm.Services.Caller.IoC
{
    using Api;
    using Logger;
    using Data.Repositories;
    using ShoppingCart;
    using ShoppingCart.Api;
    using ShoppingCart.Norms.Validations.Api;
    using ShoppingCart.Norms.Validations;
    using global::Lsm.Services.Component.Requisitions.Api;
    using global::Lsm.Services.Component.Requisitions.Services;

    public static class ServicesContainer<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Package(IUnityContainer container)
        {
            container
                .RegisterType<ILogger, BaseLogger>()
                .RegisterType<IRepositoryStoreManager, RepositoryStoreManager>()
                .RegisterType<IValidationCallbackContainer, ValidationCallbackContainer>()
                .RegisterType<ISurveyInterfaceEntries, SurveyInterfaceEntries>()
                .RegisterType<IShoppingCartRepository,   ShoppingCartRepository>()
                .RegisterType<IServicesContainerManager, ServicesContainerManager>();
        }
    }
}
