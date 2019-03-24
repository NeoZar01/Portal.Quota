using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Quota.Repositories.Services.Contracts
{
    using Data.Models;

    public interface IShoppingCartService 
    {
        decimal GetTotalPrice(string id);
        ShoppingCart CreateInstance(string id);
        int MoveToCard(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity);
        Task<int> MoveToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity);
        void RemoveFromCard(string Id);
        Task<IEnumerable<ShoppingCartItems>> GetAll<TModel>(string reqId) where TModel : class;
        void CheckOut(string Id, out string outcome);
    }
}
