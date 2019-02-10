using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Repository.Services.Local.Api
{
    using Data.Repositories.EF;
    using Lsm.ShoppingCart.Api;
    using Web.Services.Component.Cache.Proxies;

    public interface IShoppingCartService : IShoppingCartRepository
    {

        Task<ShoppingCardModelProxy> LoadCartInstanceAsync(string instanceId);

        Task<int> AddToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity);

        Task<IEnumerable<vw_ShoppingCardItems>> ShoppingCardListAsync(string reqId, int id);

        Task<int> CheckOut(string entityId, int sender, int receiver);

        decimal GetTotalPrice<T>(string entityType, string entityId, int id) where T : class;

        void RemoveFromCard(string entityType, string entityId, string itemId);
    }
}
