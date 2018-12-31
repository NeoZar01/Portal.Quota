using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Areas.Services.Controllers
{

    using Api;
    using Logger;
    using Data.Repositories;

    public class ServicesController : BaseControllerWebApi 
    {


        #region Helpers
            public ServicesController(ILogger logger, IRepositoryStoreManager dataStore)  : base(logger, dataStore) {}
        #endregion
    }
}