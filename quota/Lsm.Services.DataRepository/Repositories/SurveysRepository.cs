using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.Repositories
{
    using System.Data.Entity;
    using DoE.Lsm.Data.Repositories.Models;
    using Logger;
    using Repository.Surveys;

    public class SurveysRepository : Repository<Surveys>, ISurveysRepository
    {
        public SurveysRepository(DbContext context, ILogger logger) : base(context, logger)
        {}

        /// <summary>
        ///    No implementations should be done on this method since it is overridden by the service call.
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        public Surveys LoadSurveyEntities(string emisCode)
        {
            return null;
        }
    }
}
