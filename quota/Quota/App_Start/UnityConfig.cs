using System;

namespace DoE.Quota.Web
{
    using Api;
    using Controllers;
    using Microsoft.Practices.Unity;
    using Repositories.Services.IoC;

    /// <summary>
    ///         Users Microsoft Unity 3.0 to configure container for IoC
    /// </summary>
    public class UnityConfig
    {

        /// <summary>
        ///         Setup the main object container
        /// </summary>
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>( () => 
        {
                var container = new UnityContainer();
                    Register(container);
                return container;
        });

        /// <summary>
        ///      Add dependant containers
        ///      Add dependancies
        /// </summary>
        /// <param name="container"></param>
        public static void Register(IUnityContainer container)
        {
            RepositoryUnityContainer<IUnityContainer>.BootstrapServices(container);
            container.RegisterType<BaseController>();
            container.RegisterType<HomeController>();
            container.RegisterType<AccountController>();            
        }

        /// <summary>
        ///     loads the container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer LoadContainer ()
        {
            return container.Value;
        }

    }
}