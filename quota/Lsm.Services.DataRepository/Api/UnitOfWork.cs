using System;

namespace DoE.Lsm.Data.Repositories
{
    using Logger;
    using Persons;
    using EF;
    using Orders;
    using Subcity;
    using Inventories;
    using Search;

    public class UnitOfWork : IUnitOfWork
   {

        private readonly ILogger _logger;
        private readonly PortalLsm     _ProductionDbContext;
        private readonly PortalAuth    _authenticationDbContext;        

        public UnitOfWork(ILogger logger)
        {
                        _ProductionDbContext     = new PortalLsm();
                        _authenticationDbContext = new PortalAuth();

                        InventoryService   = new InventoryRepository(_ProductionDbContext, logger);
                        RequisitionService = new RequisitionRepository(_ProductionDbContext, logger);
                        OrdersService      = new OrderRepository(_ProductionDbContext, logger);                      
                        SubcityService     = new SubcityRepository(_ProductionDbContext, logger);
                        UserService        = new UserRepository(_authenticationDbContext, logger);
                        EnrolmentService   = new EnrolmentRepository(_ProductionDbContext, logger);
        }

        public InventoryRepository      InventoryService        { get; set; }
        public RequisitionRepository    RequisitionService      { get; set; }
        public OrderRepository          OrdersService           { get; set; }
        public EnrolmentRepository      EnrolmentService        { get; set; }
        public UserRepository           UserService             { get; set; }
        public SubcityRepository        SubcityService          { get; set; }
        public SearchRepository         SearchService           { set; get; }

        #region Gabbage Collection
        private bool _disposed = false;
        private static readonly object _syncLock = new object();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _ProductionDbContext.Dispose();
            }
        }
        #endregion
    }
    }
