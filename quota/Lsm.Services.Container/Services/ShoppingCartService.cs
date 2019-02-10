
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Repository.Services.Local
{
    using Api;
    using Data.Repositories.EF;
    using Lsm.ShoppingCart.Api;
    using Web.Services.Component.Cache.Proxies;

    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            this._shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<int> AddToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity)
        {
               return await _shoppingCartRepository.AddToCardAsync(inventoryId, instanceId, reqNo, emisCode, calendar, surveyKey, minGrade, maxGrade, status, quantity);
        }

        public Task<int> CheckOut(string entityId, int sender, int receiver)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice<T>(string entityType, string entityId, int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCardModelProxy> LoadCartInstanceAsync(string instanceId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCard(string entityType, string entityId, string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<vw_ShoppingCardItems>> ShoppingCardListAsync(string reqId, int id)
        {
            throw new NotImplementedException();
        }

        Task<Web.Services.Component.Cache.Proxies.ShoppingCardModelProxy> IShoppingCartRepository.LoadCartInstanceAsync(string instanceId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<vw_ShoppingCardItems>> IShoppingCartRepository.ShoppingCardListAsync(string reqId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
