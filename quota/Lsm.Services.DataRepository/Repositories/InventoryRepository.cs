using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repositories.Inventories
{

    using EF;
    using Logger;
    using Repositories;
    using WF.Engine.Context;

    public class InventoryRepository : Repository<Inventory> , IInventoryRepository
    {

        public void UpdateInventory(string inventoryId, int quantity)
        {
            var entityId = Guid.Parse(inventoryId);

            var entity = db.Inventories.Where( c => c.InstanceId.Equals(entityId)).SingleOrDefault();
                entity.LastModifiedDate = DateTime.Now;

            var results =  _DbContext.SaveChanges();

            if ((ExecutionResult)results != ExecutionResult.Success) throw new ApplicationException("An error occured while updating your inventory item.Please contact your administrators about this issue.");
        }

        public Inventory IsInventoryAvailable(string inventoryId, int quantity)
        {

            var instanceId = Guid.Parse(inventoryId);

            var entity = db.Inventories.Where( c => c.InstanceId.Equals(instanceId))
                                       .Where( C => C.Quota >= quantity )
                                       .SingleOrDefault();

            if (entity != null) return entity;

            return null;
        }

        public void SubEntityUpdatesCallback<T1, T2>(string requisitionId, string parentEntityId, int quantity, int categoryCD, string emisCode, decimal price) where T1 : class
        {

            var instanceId = Guid.NewGuid();

            var entity = new InventoryRequest
                             {   CategoryCD = categoryCD , CreationDate = DateTime.Now , EmisToken = emisCode ,
                                 LastModifiedDate = DateTime.Now, ParentEntityId = parentEntityId , Price = price , Quantity = quantity , ReqId = requisitionId , InstanceId = instanceId };

            db.InventoryRequests.Add(entity);

            var results = db.SaveChanges();

            if ((ExecutionResult)results != ExecutionResult.Success) throw new ApplicationException("An error occured while updating your inventory item.Please contact your administrators about this issue.");
        }

        #region Inventory List
        //public IEnumerable<string> Predict(int emisCode, string keyword, string bookYear)
        //{

        //    var searchQuery = (from k in DbContext.vw_Inventory 
        //                       where
        //                       (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
        //                      || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
        //                       select k)
        //                      .OrderBy(c => c.Grade)
        //                      .OrderBy( c => c.BookName)
        //                      .Select(c => c.BookName);

        //    foreach (var i in searchQuery)
        //    {
        //        yield return i;
        //    }
        //}


        //public IEnumerable<vw_Inventory> InventoryList([Dimensions(Calendar | BookYear )]int emisCode, string keyword, string bookYear)
        //{

        //    var searchQuery = (from k in DbContext.vw_Inventory
        //                       where
        //                      (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword) || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
        //                       select k)
        //                      .OrderBy(c => new { c.Grade , c.BookName });

        //    foreach (var book in searchQuery)
        //    {
        //        yield return book;
        //    }
        //}
        #endregion

        #region Helpers
        public InventoryRepository(PortalLsm DbContext, ILogger logger) : base(DbContext, logger) { }
        private PortalLsm db { get { return this._DbContext as PortalLsm; } }
        #endregion
    }
}