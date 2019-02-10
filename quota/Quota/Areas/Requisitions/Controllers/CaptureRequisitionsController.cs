using System.Web.Mvc;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Areas.Requisitions.Controllers
{
    using Api;
    using Data.Repositories;
    using Logger;
    using Repository.Services.Local.Api;
    using Web.Services.Models;
    using Web.Services.Validations.Api;
    using Web.Services.Web.Session.Cache;

    [Authorize(Roles ="School")]
    public class CaptureRequisitionsController : BaseController
    {

        public CaptureRequisitionsController(ILogger logger, IUnitOfWork dataStore, IShoppingCartService shoppingCart, IValidationCallbackProvider validationProvider, IGlobalCache globalcache)
            : base(logger, dataStore, shoppingCart , validationProvider, globalcache)
        { }

        public async Task<ActionResult> Index(string instanceId)
        {
            var shoppingcartModel = await _shoppingCart.LoadCartInstanceAsync(instanceId);
            return View((ShoppingCartViewModel)shoppingcartModel);
        }
    }
}
