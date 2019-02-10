using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Runtime.CompilerServices;

namespace DoE.Lsm.Web.Api
{
    using Logger;
    using Models;
    using Services.Api;
    using Data.Repositories;
    using Lsm.ShoppingCart.Api;
    using Services.Validations.Api;
    using Services.Web.Session.Cache;
    using global::Lsm.Services.Mvc.Component.SessionCache.Api;
    using Services.Web.Session.Cache.Models;

    [Authorize]
    public class BaseController : Controller , IGlobalCache
    {

        #region   CONSTRUCTOR IMPLEMENTATION

        public readonly ILogger _logger;
        public readonly IUnitOfWork _uow;
        public readonly IShoppingCartRepository _shoppingCart;
        public readonly IValidationCallbackProvider _validationCallback;
        public readonly IGlobalCache _globalCache;

        public BaseController(ILogger logger, IUnitOfWork uow, IShoppingCartRepository shoppingcart, IValidationCallbackProvider validationContainer, IGlobalCache globalCache)
        {
            this._logger = logger;
            this._uow = uow;
            this._shoppingCart = shoppingcart;
            this._validationCallback = validationContainer;
            this._globalCache = globalCache;
        }

        public BaseController()
        {}
        #endregion      

        public new void OnException(ExceptionContext filterContext)
        {

            base.OnException(filterContext);
        }

        public new void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var test_ = "Hello World Cup!!!!";

            base.OnActionExecuting(filterContext);
        }

        public void AddItem<TModel>(string key, TModel item)
        {
            _globalCache.AddItem<TModel>(key, item);
            System.Web.HttpContext.Current.Session[key] = item;
        }

        public void RemoveItem<TModel>(string key)
        {
            _globalCache.RemoveItem<TModel>(key);
            System.Web.HttpContext.Current.Session[key] = null;
        }

        public void RefreshItem<TModel>(string key, TModel item)
        {
            _globalCache.RefreshItem<TModel>(key, item);

            System.Web.HttpContext.Current.Session[key] = null;
            System.Web.HttpContext.Current.Session[key] = item;
        }

        public SessionCache SetupSessionCache() 
        {
            AddItem<string>(CacheKey.EmisCode, User.Identity.GetUserName());
            AddItem<string>(CacheKey.IdentityId, User.Identity.GetPersonalId());

            return new SessionCache { EmisCode = Get<string>(CacheKey.EmisCode),  IdentityId = Get<string>(CacheKey.IdentityId)};
        }

        public TModel Get<TModel>(string key)
        {
            return _globalCache.Get<TModel>(key);
        }
    }      
}