using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.Inventories
{

    using Repositories;
    using Repositories.EF;
    using WF.Engine.Context;

    public interface IInventoryRepository : IRepository<Inventory>
    {

        /// <summary>
        ///     Checks if the item is available in the inventory
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="quantity"></param>
        /// <returns>Returns null if the item is not available.</returns>
        Inventory IsInventoryAvailable(string inventoryId, int quantity);

        /// <summary>
        ///  Update inventory
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        void UpdateInventory(string inventoryId, int quantity);

        ///<summary>
        /// Update subEntities
        ///<remark>
        ///  First 2 paramenters ensures that all referencial integrity rules are satisfied.
        ///</remark>
        ///<param name="reqId">Requisition Reference Number</param>
        ///<param name="invInstanceId"> Requisition Item Id</param>
        ///<param name="invQty"> Inventory Request Object</param>
        ///</summary>
        void SubEntityUpdatesCallback<T1, T2>(string requisitionId, string parentEntityId, int quantity, int categoryCD, string emisCode, decimal price ) where T1 : class;

        /**
         *  Gets the names of items in the inventory list.
         */
        ///<summary>
        /// Gets the names of items in the inventory list.
        ///</summary>
        //      IEnumerable<string>  Predict([Dimensions(BookYear | Calendar )]int emisCode, string bookYear, string keyword);

        /**
         *  Gets an inventory list.
         */
        ///<summary>
        /// Gets an inventory list.
        ///</summary>
        //      IEnumerable<vw_Inventory>   InventoryList([Dimensions(BookYear | Calendar)] int emisCode, string bookYear, string keyword );


    }

}
