using System;
using System.Web.Mvc;
using System.Collections.Generic;

using Microsoft.Practices.Unity;

namespace DoE.Quota.Web.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class UnityServicesProvider : IDependencyResolver
    {

        private readonly IUnityContainer _container;

        public UnityServicesProvider(IUnityContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            if (!this._container.IsRegistered(serviceType))
            {
                return null;
            }
            return this._container.Resolve(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!this._container.IsRegistered(serviceType))
            {
                return new List<object>();
            }
            return this._container.ResolveAll(serviceType);
        }
    }
}