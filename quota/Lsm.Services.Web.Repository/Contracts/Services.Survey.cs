namespace DoE.Quota.Repositories.Services.Contracts
{
    using Repositories.Data.Api;
    using Repositories.Data.Models;

    public interface ISurveyService  
    {
         Survey LoadSurveyEntities(string emisCode);
    }
}