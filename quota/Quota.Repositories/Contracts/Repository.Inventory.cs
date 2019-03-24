using System.Threading.Tasks;

namespace DoE.Quota.Repositories.Data.Api
{
    using EF;
    using Core.Repositories.Data.Contracts;


    public interface IInventoryRepository : IRepository<Inventory>
    {

        Inventory IsInsideInventory(string id, int quantity);
        void UpdateInventory(string id, int quantity);
        void SubEntityUpdatesCallback<T1, T2>(string requisitionId, string parentEntityId, int quantity, int categoryCD, string emisCode, decimal price ) where T1 : class;

        #region [Old] Repository Code 

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

        //IEnumerable<string> GetTopBooks(int emisCode, string keyword, string bookYear , int count);

        //IEnumerable<string> GetSubjectsFilterFormatter(int emisCode, string keyword , string bookYear);

        //IPagedList<vw_RequisitionOrderItems> GetBookmarks([Term(BookYear = Term.Parameter.Mandatory)]int emisCode , string bookYear , int? page);

        ////IEnumerable<vw_Inventory> GetBooksSharingSimilarAttributes(vw_Inventory item , int count);

        //string GetDefaultSubjectsFilterFormatter(int emisCode, string keyword, string bookYear);

        //IPagedList<vw_RequisitionOrderItems> GetBooksByPaging([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, int? page, string bookYear);

        //IPagedList<vw_RequisitionOrderItems> GetOrderedItems([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, string bookYear, int? page);

        //Task<int> SetItemToBookmarkedRegistryAsync(int emisCode);

        //Task<int> RemoveItemFromBookmarkRegistryAsync(int emisCode);

        ////vw_Inventory GetCatalogueItem(int emisCode);



        #endregion
    }

}
