using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Areas.Services.Controllers
{

    using Api;
    using Logger;
    using Data.Repositories;
    using Web.Services.Component.Cache;
    using Web.Services.Validations.Api;
    using Web.Services.Web.Session.Cache;

    public class ServicesController : BaseControllerWebApi 
    {

        public ServicesController() { }

        public readonly IGlobalCache _globalCache;
        public readonly IValidationCallbackProvider _validationContainer;
        public readonly ILogger _logger;
        public readonly IUnitOfWork _repositoryStore;

        public ServicesController(ILogger logger, IUnitOfWork repositoryStore, IValidationCallbackProvider validationContainer, IGlobalCache globalCache)
        {
            this._logger = logger;
            this._repositoryStore = repositoryStore;
            this._validationContainer = validationContainer;
            this._globalCache = globalCache;
        }
    }
}