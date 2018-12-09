using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Areas.RestAPI.Controllers
{
    using Api;
    using Logger;
    using Data.Repositories;

    public class RequisitionsServicesController : BaseAPIController
    {



        #region  Helpers
        public RequisitionsServicesController(ILogger logger, IRepositoryStoreManager repositoryManager)
        :base(logger, repositoryManager){}
        #endregion
    }
}