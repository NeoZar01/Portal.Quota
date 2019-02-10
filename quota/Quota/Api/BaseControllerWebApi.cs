using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DoE.Lsm.Web.Api
{
    using Models;
    using Logger;
    using Data.Repositories;
    using Services.Component.Cache;
    using Services.Validations.Api;
    using Services.Web.Session.Cache;

    /// <summary>
    ///  This class should be inherited by classes that intends to be Api Controllers
    /// </summary>   
    [Authorize]
    public class BaseControllerWebApi : ApiController
    {

        //public void CacheModelProperties(IValidationCallbackProvider validationContainer, params string[] modelKeys)
        //{
        //    _globalCache.CacheModelProperties(Prefetch, GetType().ToString(), "CacheModelProperties", 56, modelKeys);
        //}

        #region CONSTRUCTOR IMPLEMENTATIONS
        public BaseControllerWebApi() { }

        public readonly IGlobalCache _globalCache;
        public readonly IValidationCallbackProvider _validationContainer;
        public readonly ILogger _logger;
        public readonly IUnitOfWork _repositoryStore;

        public BaseControllerWebApi(ILogger logger, IUnitOfWork repositoryStore, IValidationCallbackProvider validationContainer, IGlobalCache globalCache)
        {
            this._logger = logger;
            this._repositoryStore = repositoryStore;
            this._validationContainer = validationContainer;
            this._globalCache = globalCache;
        }

        #endregion
    }
}
