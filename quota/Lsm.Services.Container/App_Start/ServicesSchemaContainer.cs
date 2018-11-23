using Microsoft.Practices.Unity;

namespace DoE.Lsm.Services.Caller.IoC
{
    using Api;
    using Logger;
    using ShoppingCard.Api;
    using Data.Repositories;

    public static class ServicesSchemaContainer<T>
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
                .RegisterType<IShoppingCard, ShoppingCard>()
                .RegisterType<ISchemaRegistry, Schema>();
        }
    }
}
