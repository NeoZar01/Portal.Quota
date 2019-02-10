using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DoE.Lsm.Web.Controllers
{
    using Models;
    using Api;
    using Logger;
    using Data.Repositories;

    using Services.Validations.Api;
    using Services.Web.Session.Cache;
    using Repository.Services.Local.Api;
    using Lsm.Services.Identity.Claims.GroupPolicy.Resources;

    [Authorize]
    public class HomeController : BaseController
    {

        private readonly Dictionary<string, HomePageBuilder> modelDictionary = new Dictionary<string, HomePageBuilder>();

        public HomeController(ILogger log, IUnitOfWork uow, IShoppingCartService shoppingCart, IValidationCallbackProvider validationCallback, IGlobalCache cache)  
            : base(log, uow, shoppingCart, validationCallback, cache)
        {
            modelDictionary.Add(ModelKeys.SchoolDashboardViewModel, new SchoolHomePageViewModel(ModelKeys.SchoolDashboardViewModel));
            modelDictionary.Add(ModelKeys.AdministratorDashboardViewModel, new AdministratorDashboardViewModel(ModelKeys.AdministratorDashboardViewModel));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var sessionCache = SetupSessionCache();

            if(sessionCache != null)
            {
                return View( modelDictionary[sessionCache.IdentityRole].ResolveHypertext<HomePageBuilder>(_uow, _validationCallback, null, sessionCache.IdentityId));
            }
                return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [ChildActionOnly]
        public ActionResult BuildDashboard(HomePageBuilder model)
        {
            return PartialView(model.Page.IsNull("_mainpagedashboard_error"), model);
        }
    }
}