﻿using System;

namespace DoE.Lsm.Web
{
    using Api;
    using Controllers;
    using Microsoft.Practices.Unity;
    using Services.Caller.IoC;

    /// <summary>
    ///         Users Microsoft Unity 3.0 to configure container for IoC
    /// </summary>
    public class IoCConfig
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
        /// </summary>
        /// <param name="container"></param>
        public static void Register(IUnityContainer container)
        {
            ServicesSchemaContainer<IUnityContainer>.Package(container);
            container.RegisterType<BaseController>();
            container.RegisterType<HomeController>();
            //container.RegisterType<CaptureController>();
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