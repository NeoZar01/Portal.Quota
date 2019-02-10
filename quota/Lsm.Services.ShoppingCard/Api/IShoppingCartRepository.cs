using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.ShoppingCart.Api
{
    using Annotations;
    using Data.Repositories.EF;
    using Web.Services.Component.Cache.Proxies;

    public interface IShoppingCartRepository
    {

       Task<ShoppingCardModelProxy> LoadCartInstanceAsync(string instanceId);

        Task<int> AddToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity);

        Task<IEnumerable<vw_ShoppingCardItems>> ShoppingCardListAsync(string reqId, int id);

        Task<int> CheckOut(string entityId, int sender, int receiver);

        decimal GetTotalPrice<T>([InstanceType(entities: "Requisitions, Orders")]string entityType, string entityId, int id) where T : class;

        void RemoveFromCard([InstanceType(entities: "Requisitions, Orders")]string entityType , string entityId , string itemId );

    }
}