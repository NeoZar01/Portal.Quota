using System;

namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCart.Api;

    /// <summary>
    /// 
    /// </summary>
    public class ServicesContainerManager : IServicesContainerManager
    {

        /// <summary>
        ///         constructor
        /// </summary>
        /// <param name="logger"></param>
        public ServicesContainerManager(ILogger logger, IShoppingCartRepository shoppingcard)
        {
            //newup the EventLogger from the container
            Logger       = logger;
            //newup the shoppingcard from the container
            ShoppingCard = shoppingcard;
        }

        public ILogger Logger
        { get; set; }

        public IShoppingCartRepository ShoppingCard
        { get; set; }
    }

}
