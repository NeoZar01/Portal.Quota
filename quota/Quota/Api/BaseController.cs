using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace DoE.Lsm.Web.Api
{

    using Logger;
    using Data.Repositories;
    using ShoppingCart.Api;
    using ShoppingCart.Norms.Validations.Api;

    /// <summary>
    ///    This class should be inherited by classes that intends to be Controllers
    /// </summary>   
    [Authorize]
    public class BaseController : Controller
    {

        #region   Helpers

        public readonly ILogger _logger;
        public readonly IRepositoryStoreManager _repositoryStore;
        public readonly IShoppingCartRepository _shoppingCart;
        public readonly IValidationCallbackContainer _validationContainer;

        public BaseController(ILogger logger, IRepositoryStoreManager repositoryStore, IShoppingCartRepository shoppingcart, IValidationCallbackContainer validationContainer)
        {
            this._logger = logger;
            this._repositoryStore = repositoryStore;
            this._shoppingCart = shoppingcart;
            this._validationContainer = validationContainer;
        }

        public BaseController() { }
        #endregion

        /// <summary>
        ///    Returns Emis Code
        /// </summary>
        public virtual int EmisCode { get { return User.Identity.GetUserName().ToInt(); } }

        /// <summary>
        ///    Returns Survey Code
        /// </summary>
        public virtual string SurveyCD { get { return _repositoryStore.SnE.SurveyCD; } }

        /// <summary>
        ///    Returns survey Id
        /// </summary>
        public virtual string SurveyId { get { return _repositoryStore.SnE.SurveyId; } }

        /// <summary>
        ///    returns PersonId 
        /// </summary>
        public virtual string PersonId { get { return User.Identity.PersonId(); } }

    }
}