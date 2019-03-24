using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

using Core.Globalization;
using Core.Data.Globalization;

namespace DoE.Quota.Web.Api
{
    using Models;
    using Entities;

    using Core.Models.Common;
    using Core.Identity.Claims;

    using Repositories.Services.Contracts;
    using Core.Web.Utilities.Common;
    using Core.Models;

    [Authorize]
    public class BaseController : Controller 
    {
        public static ModelCollection modelCollector;


        #region   [::CONSTRUCTOR::]

        static BaseController()
        {
            modelCollector = ModelCollection.InitializeCollector();
        }

        protected readonly IShoppingCartService _shoppingCart;
        public BaseController(IShoppingCartService shoppingcart)
        {
            this._shoppingCart = shoppingcart;
        }

        public BaseController()
        {}
        #endregion      

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

          if (System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Contains("~/Home/Index"))
            {
                //TODO Handle home page refresh instructions. 
            }

            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Contains("LogOff"))
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
            }

            base.OnResultExecuted(filterContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        protected IModel ResolveViewModel(IEnumerable<KeyValuePair<string, string>> claims)
        {
            IModel vmodel = null;

            foreach(var claim in claims)
            {
                if (claim.Value.Equals(DefaultDbValue.TRUE))
                {
                    modelCollector.Resolve<HomeViewModel>(claim.Key, out vmodel);
                }

                if (vmodel != null) break;
            }


            if (vmodel == null)
            {
                modelCollector.Resolve<HomeViewModel>(GroupPolicy.EVERYONE_CAN_VIEW, out vmodel);
            }

            return vmodel;
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupPolicy GroupPolicyCache
        {
            get
            {
                var groupPolicy = HttpContext.Cache.Get(CacheKeys.GROUP_POLICY);

                if(groupPolicy != null)
                {
                    return groupPolicy as GroupPolicy;
                }
                return null;
            }
        }

        public CallInfo RequestInfo
        {
            get
            {
                string id = Guid.NewGuid().ToString();

                var currentRequest = new CallInfo
                {
                    Controller  = RouteData.Values["Controller"].ToString(),
                    Action      = RouteData.Values["Action"].ToString(),
                    CallVerb    = System.Web.HttpContext.Current.Request.HttpMethod
                };

                currentRequest.CallTime = DateTime.Now;
                currentRequest.Id       = id;                             
                return currentRequest;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl, IModel viewModel)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", viewModel);
        }

        #region [::Global Cache Methods::]
        //public void Add(string key, CacheVariable variable)
        //{
        //    _globalCache.Add(key, variable);
        //}

        //public void KillKey(string key)
        //{
        //    _globalCache.KillKey(key);
        //}

        //public void RefreshKey(string key, CacheVariable checksum, out CacheVariable output)
        //{
        //    _globalCache.RefreshKey(key, checksum, out output);
        //}

        //public CacheVariable Get(string key)
        //{
        //    return _globalCache.Get(key);
        //}

        //public CacheVariable TryGet(string key, CacheVariable checksum)
        //{
        //   return _globalCache.TryGet(key, checksum);
        //}


        //public void GetPrefetch(out GlobalParameters globalParameters)
        //{

        //    if (Get(GlobalCacheKeys.PREFETCH) == null)
        //    {
        //        var parameters = new GlobalParameters { EmisCode = User.Identity.GetUserName(), UserId = User.Identity.GetUserId() };

        //        Add(GlobalCacheKeys.PREFETCH, CacheVariable.Push(parameters, VariableStatus.IsAlive));
        //    }

        //    globalParameters = Get(GlobalCacheKeys.PREFETCH).Value as GlobalParameters;
        //}

        #endregion
    }
}