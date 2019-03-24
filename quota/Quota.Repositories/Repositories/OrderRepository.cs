
namespace DoE.Quota.Repositories.Data.Order
{

    using EF;
    using Api;
    using Models;

    using Core.Logger.Api;
    using Core.Repositories.Data;

    public class OrderRepository : Repository<Order>, IOrdersRepository
    {
        public OrderRepository() {}

        //
        /*
         --> Pools a list of orders per grade per bookyear from the vw_rqLimp_OrderItems view
             and re-populate the results into the OrderPerGradeDashboardApp app which then return an IEnumerable list
             of ...
        */
        //public IEnumerable<vw_Inventory> GetOrdersPerGradePerBookYear(int emisCode, int grade, string bookYear)
        //{
        //    return OrderDbContext.vw_Inventory
        //           .Where(c => (c.EmisCode == emisCode) && (c.Grade == grade) && (c.BookYear.Equals(bookYear)))
        //           .OrderBy( c => c.BookYear);
        //}


        //public IQueryable<vw_Inventory> GetOrdersPerGradePerBookYearQueryable(int emisCode, int grade, string bookYear)
        //{
        //    //return OrderSchema.LsmRequisitionItems
        //    //       .Where(c => (c.Emis_Code == emisCode) && (c.Grade == grade) && (c.Bookyear.Equals(bookYear)))
        //    //       .OrderBy(c => c.Grade);                                     

        //    return OrderDbContext.vw_Inventory
        //                      .Where(c => (c.EmisCode == emisCode) && (c.Grade == grade) && (c.BookYear.Equals(bookYear)))
        //                      .OrderBy(c => c.BookYear);
        //}


        //public IEnumerable<InventoryList> GetOrderList(string reqID, string bookYear, int emisCode)
        //{
        //    //add requisition validation 
        //    var orderItemsQuery =  OrderDbContext.Inventories
        //                                      .Where(c => (c.EmisCode == emisCode) && (c.BookYear.Equals(bookYear)))
        //                                      .OrderBy(c => c.BookYear);

        //    foreach (var e in orderItemsQuery)
        //            {
        //                        yield return e;
        //            }
        //}

        //public decimal RequisitionTotalPrice(string reqID)
        //{
        //    try
        //    {
        //        var requisition = OrderDbContext.req_vwRequisitionTotalPrice
        //                                    .Where(c => c.ReqId.Equals(reqID))                                           
        //                                    .SingleOrDefault();
        //        return requisition.TotalPrice ?? 0.0M ;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}
    }
}