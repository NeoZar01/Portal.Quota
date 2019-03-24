
namespace DoE.Quota.Repositories.Data.Enrolments
{
    using EF;
    using Api;
    using Models;

    using Core.Logger.Api;
    using Core.Repositories.Data;

    public class StatisticsRepository : Repository<Statistics>, IStatisticsRepository
    {
        public StatisticsRepository() {}    
    }
}
