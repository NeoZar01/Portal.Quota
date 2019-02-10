using System;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repository.Surveys
{
    using Repositories;
    using Repositories.Models;

    public interface ISurveysRepository : IRepository<Surveys>
    {
        Surveys LoadSurveyEntities(string emisCode);
    }
}