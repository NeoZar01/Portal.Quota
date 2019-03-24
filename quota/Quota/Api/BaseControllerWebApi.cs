using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DoE.Quota.Web.Api
{

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

        #region [CONSTRUCTOR] 
        public BaseControllerWebApi() {}
        #endregion
    }
}
