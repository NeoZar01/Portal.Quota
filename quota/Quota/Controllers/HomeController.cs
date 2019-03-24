using System.Web.Mvc;

namespace DoE.Quota.Web.Controllers
{
    using Api;
    using Models;
    using Entities;

    using Core.Identity.Claims;
    using Core.Extensions;
    using Core.Models.Common;

    using Repositories.Services.Contracts;

    [Authorize]
    public class HomeController : BaseController
    {

        protected readonly IShoppingCartService _shoppingCartService;
        public HomeController(IShoppingCartService shoppingCartService) : base(shoppingCartService) {}

        [HttpGet]
        public ActionResult Index()
        {
            IModel model = null;
          
            if (GroupPolicyCache != null)
            {
                model = ResolveViewModel(GroupPolicyCache.GetAllPolicies())
                        .Get<AdmnistratorHomeViewModel>(GroupPolicy.CAN_VIEW_ADMINISTRATION_HOMEPAGE)
                        .Or<SchoolHomePageViewModel>(GroupPolicy.CAN_VIEW_SCHOOL_HOMEPAGE);

                return View(model);
            }
            //[TODO] Create view model for guests
            model = ResolveViewModel(GroupPolicyCache.GetAllPolicies())
                        .Get<SchoolHomePageViewModel>(GroupPolicy.EVERYONE_CAN_VIEW);
           
            return View(model);
        }

        //public GlobalParameters globalParams = null;
        [HttpGet]
        [ChildActionOnly]
        public ActionResult RenderHomePage(HomeViewModel model)
        {
            return PartialView(model.View.IsNull("_mainpagedashboard_error"), model);
        }
    }
}