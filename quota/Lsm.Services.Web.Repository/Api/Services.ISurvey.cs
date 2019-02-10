using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Services.Web.Repository.Api
{
    using Data.Repository.Surveys;
    using Data.Repositories.Models;

    public interface ISurveyService : ISurveysRepository
    {
        new Surveys LoadSurveyEntities(string emisCode);
    }
}