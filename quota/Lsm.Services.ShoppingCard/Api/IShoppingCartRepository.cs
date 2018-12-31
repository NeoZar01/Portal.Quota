using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.ShoppingCart.Api
{
    using Proxies;
    using Annotations;
    using Data.Repositories.EF;

    public interface IShoppingCartRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
       Task<ShoppingCartProxyModel> LoadCartInstanceAsync(string instanceId);

        ///<summary> 
        ///      Adds a new entity into the shopping card
        ///</summary>
        Task<int> AddToCard(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar, string surveyKey, byte minGrade, byte maxGrade, string status, int quantity);

        ///<summary>
        ///      Pools a list of all items in the card
        ///</summary>
        Task<IEnumerable<vw_ShoppingCardItems>> ShoppingCardListAsync(string reqId, int id);

        ///<summary>
        ///     Checkout to rimit process
        ///</summary>
        Task<int> CheckOut(string entityId, int sender, int receiver);

        ///<summary>
        ///      Gets the total price of the card.
        ///</summary>
        decimal GetTotalPrice<T>([InstanceType(entities: "Requisitions, Orders")]string entityType, string entityId, int id) where T : class;

        ///<summary>
        ///      Remove an item from the car list.
        ///</summary>
        void RemoveFromCard([InstanceType(entities: "Requisitions, Orders")]string entityType , string entityId , string itemId );

    }
}