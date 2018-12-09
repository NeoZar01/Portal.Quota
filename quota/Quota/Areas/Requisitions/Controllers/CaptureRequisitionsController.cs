using System.Web.Mvc;

namespace DoE.Lsm.Web.Areas.Requisitions.Controllers
{
    using Api;
    using Data.Repositories;
    using Logger;
    using Models;
    using ShoppingCart.Api;
    using ShoppingCart.Norms.Validations.Api;
    using System.Threading.Tasks;

    [Authorize(Roles ="School")]
    public class CaptureRequisitionsController : BaseController
    {

        public CaptureRequisitionsController(ILogger logger, IRepositoryStoreManager dataStore, IShoppingCartRepository shoppingCart, IValidationCallbackContainer validationContainer) : base(logger, dataStore, shoppingCart , validationContainer)
        { }


        public async Task<ActionResult> Index(string instanceId)
        {

            var shoppingcartModel = await _shoppingCart.LoadCartInstanceAsync(instanceId);

            return View((ShoppingCartViewModel)shoppingcartModel);
        }
    }
}
