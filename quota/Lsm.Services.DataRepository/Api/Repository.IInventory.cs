/**
 *
 */
///<summary>
///
///</summary>
namespace DoE.Lsm.Data.Repository.Inventories
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Repositories;
    using Repositories.EF;
    using Annotations;

    using static Annotations.Dimensions;

    public interface IInventoryRepository : IRepository<object>
    {
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

        /**
         *   Updates an inventory item
         */
        ///<summary>
        ///   Updates an inventory item
        ///</summary>
   //     Task<ExecutionResult> UpdateAsync(Inventory inventory , int qty);

        /**
         *  Updates an inventory item
         */
        ///<summary>
        /// Updates an inventory item
        ///<remark>
        ///  First 2 paramenters ensures that all referencial integrity rules are satisfied.
        ///</remark>
        ///<param name="reqId">Requisition Reference Number</param>
        ///<param name="invInstanceId"> Requisition Item Id</param>
        ///<param name="invQty"> Inventory Request Object</param>
        ///</summary>
  //      Task<ExecutionResult> SaveListItemAsync(string reqId , string invInstanceId, InventoryRequest invRequest);
    }

}
