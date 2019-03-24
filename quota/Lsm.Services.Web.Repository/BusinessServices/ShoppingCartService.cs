
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Quota.Repositories.BusinessServices
{
    using Data.Api;
    using Data.EF;
    using Data.Models;
    using Services.Contracts;

    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IInventoryRepository _shoppingCartRepository;

        public ShoppingCartService(IInventoryRepository shoppingCartRepository)
        {
            this._shoppingCartRepository = shoppingCartRepository;
        }

        public void CheckOut(string Id, out string outcome)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart CreateInstance(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCartItems>> GetAll<TModel>(string reqId) where TModel : class
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice(string id)
        {
            throw new NotImplementedException();
        }

        public int MoveToCard(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> MoveToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity)
        {
            throw new ApplicationException();//await _shoppingCartRepository.MoveToCardAsync(inventoryId, instanceId, reqNo, emisCode, calendar, surveyKey, minGrade, maxGrade, status, quantity);
        }

        public void RemoveFromCard(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
