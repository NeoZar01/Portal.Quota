using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DoE.Lsm.Web.Api
{
    using Logger;
    using Data.Repositories;

    /// <summary>
    ///  This class should be inherited by classes that intends to be Api Controllers
    /// </summary>   
    [Authorize]
    public class BaseControllerWebApi : ApiController
    {
        public readonly ILogger _logger;
        public readonly IRepositoryStoreManager _repositoryStore;

        /// <summary>
        ///    Returns Emis Code
        /// </summary>
        public virtual int EmisCode     { get { return User.Identity.GetUserName().ToInt(); } }

        /// <summary>
        ///    Returns Survey Code
        /// </summary>
        public virtual string SurveyCD  { get { return _repositoryStore.SnE.SurveyCD; } }

        /// <summary>
        ///    Returns survey Id
        /// </summary>
        public virtual string SurveyId  { get { return _repositoryStore.SnE.SurveyId; } }

        /// <summary>
        ///    returns PersonId 
        /// </summary>
        public virtual string PersonId { get { return User.Identity.PersonId(); } }


        #region Helpers
        public BaseControllerWebApi() { }

        public BaseControllerWebApi(ILogger logger, IRepositoryStoreManager repositoryStore)
        {
            this._logger = logger;
            this._repositoryStore = repositoryStore;
        }

        #endregion
    }
}
