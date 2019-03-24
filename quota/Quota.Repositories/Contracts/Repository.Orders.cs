namespace DoE.Quota.Repositories.Data.Api
{
    using Core.Repositories.Data.Contracts;
    using Models;

    public interface IOrdersRepository : IRepository<Order>
    {        
        //IEnumerable<vw_Inventory> GetOrdersPerGradePerBookYear([Term(BookYear = Term.Parameter.Mandatory)] int emisCode, int grade, string bookYear);
        //IQueryable<vw_Inventory> GetOrdersPerGradePerBookYearQueryable([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, int grade, string bookYear);        
        //IEnumerable<InventoryList> GetOrderList([Term(BookYear = Term.Parameter.Mandatory)] string reqID, string bookYear, int emisCode);
        //decimal RequisitionTotalPrice(string reqID);
    }
}
