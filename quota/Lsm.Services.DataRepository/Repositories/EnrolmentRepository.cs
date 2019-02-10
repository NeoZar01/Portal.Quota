using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Logger;
using DoE.Lsm.Data.Repositories.Order;

namespace DoE.Lsm.Data.Repositories.Orders
{
    public class EnrolmentRepository : Repository<object>, IEnrolmentRepository
    {
        public EnrolmentRepository(PortalLsm context, ILogger logger) : base(context, logger){}    
    }
}
