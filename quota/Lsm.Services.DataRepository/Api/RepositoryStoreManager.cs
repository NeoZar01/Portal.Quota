using System;

namespace DoE.Lsm.Data.Repositories
{
    using Logger;
    using UI;
    using Persons;
    using EF;
    using Norms;
    using Repository.Inventories;
    using Orders;
    using Subcity;
    using Profile;

    public class RepositoryStoreManager : IRepositoryStoreManager
   {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly PortalLsm     _ProductionDbContext;
    
        /// <summary>
        /// 
        /// </summary>
        private readonly PortalAuth    _authenticationDbContext;
        
        public RepositoryStoreManager(ILogger logger)
        {
                        this._logger = logger;

                        _ProductionDbContext     = new PortalLsm();
                        _authenticationDbContext = new PortalAuth();

                        InventoryStore          = new InventoryRepository(_ProductionDbContext, logger);
                        StandardsAndNorms       = new NormsStandardsRepository(_ProductionDbContext, logger);
                        Requisitions            = new RequisitionRepository(_ProductionDbContext, logger);
                        Orders                  = new OrderRepository(_ProductionDbContext, logger);
                        RequisitionItem         = new InventoryRepository(_ProductionDbContext, logger);
                        Subcity                 = new RequisitionSubcityRepository(_ProductionDbContext, logger);
                        ProfileStore            = new ProfileRepository(_authenticationDbContext, logger);
                        Person                  = new PersonRepository(_authenticationDbContext, logger);
                        RequisitionOrderItems   = new RequisitionOrderItemsRepository(_ProductionDbContext, logger);
        }

                public InventoryRepository      InventoryStore
                { get; set; }

                public NormsStandardsRepository          StandardsAndNorms
                { get; set; }

                public ProfileRepository        ProfileStore
                { get; set; }

                public RequisitionRepository    Requisitions
                { get; set; }

                public OrderRepository          Orders
                { get; set; }

                public InventoryRepository RequisitionItem
                { get; set; }

                public RequisitionOrderItemsRepository RequisitionOrderItems
                { get; set; }

                public PersonRepository Person
                { get; set; }

                public RequisitionSubcityRepository Subcity
                { get; set; }

                public UIManagerRepository UI
                { set; get; }

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
