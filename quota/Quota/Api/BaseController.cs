using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace DoE.Lsm.Web.Api
{

    using Logger;
    using Data.Repositories;
    using ShoppingCart.Api;
    using ShoppingCart.Norms.Validations.Api;

    [Authorize]
    public class BaseController : Controller
    {

        public readonly ILogger _logger;
        public readonly IRepositoryStoreManager _repositoriesDataStore;
        public readonly IShoppingCartRepository _shoppingCart;
        public readonly IValidationCallbackContainer _validationContainer;

        public BaseController(ILogger logger, IRepositoryStoreManager repositoryStore, IShoppingCartRepository shoppingcart , IValidationCallbackContainer validationContainer)
        {
                            this._logger                = logger;
                            this._repositoriesDataStore = repositoryStore;
                            this._shoppingCart          = shoppingcart;
                            this._validationContainer   = validationContainer;
        }

        public BaseController() {}

        public virtual int EmisCode
        {
            get
            { return User.Identity.GetUserName().ToInt(); }
        }

        public virtual string Token
        {
            get
            { return User.Identity.GetToken(); }
        }
    }
}