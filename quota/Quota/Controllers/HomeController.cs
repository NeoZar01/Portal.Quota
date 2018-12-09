using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoE.Lsm.Web.Controllers
{
    using Models;
    using Api;
    using Logger;
    using Data.Repositories;
    using System.Threading.Tasks;
    using ShoppingCart.Api;
    using ShoppingCart.Norms.Validations.Api;

    [Authorize]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, DashboardFactoryViewModel> _entityDashBoard = new Dictionary<string, DashboardFactoryViewModel>();

        public HomeController(ILogger logger, IRepositoryStoreManager dataStore, IShoppingCartRepository shoppingCart, IValidationCallbackContainer validationContainer)  : base(logger, dataStore, shoppingCart, validationContainer)
        {
            _entityDashBoard.Add(EntityType.School, new SchoolDashboardViewModel());
            _entityDashBoard.Add(EntityType.CircuitManager, new CircuitDashboardViewModel());
            _entityDashBoard.Add(EntityType.Administrator, new AdministratorDashboardViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GIT"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(User.Identity.GetRole()) && string.IsNullOrEmpty(User.Identity.GetToken()))
                return View();

            return View(await _entityDashBoard[User.Identity.GetRole()].ReturnModel(_repositoriesDataStore , _validationContainer , null, User.Identity.GetToken()));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [ChildActionOnly]
        public ActionResult BuildDashboard(DashboardFactoryViewModel model)
        {
            return PartialView(model.Page.IsNullReplaceWith("_mainpagedashboard_error"), model);
        }
    }
}