using System;
using System.Web;
using System.Web.Mvc;

namespace DoE.Lsm.Web.Api.Filters
{

    /// <summary>
    ///      Clears session cache after logging off
    /// </summary>
    public class ClearCache : ActionFilterAttribute, IActionFilter
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuted(filterContext);
        }

    }
}