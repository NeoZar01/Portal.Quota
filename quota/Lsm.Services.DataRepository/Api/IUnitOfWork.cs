using System;

namespace DoE.Lsm.Data.Repositories
{
    using Search;
    using Orders;
    using Persons;
    using Subcity;
    using Inventories;

    public interface IUnitOfWork : IDisposable
    {
        InventoryRepository     InventoryService     { get; set; }
        RequisitionRepository   RequisitionService   { get; set; }
        UserRepository          UserService          { get; set; }
        OrderRepository         OrdersService        { get; set; }
        SubcityRepository       SubcityService       { get; set; }
        SearchRepository        SearchService        { get; set; }
    }
}
