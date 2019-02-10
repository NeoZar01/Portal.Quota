using System;

namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCart.Api;

    public class ServicesBootstrapper : IServiceBootstrapper
    {
        public ServicesBootstrapper(ILogger logger, IShoppingCartRepository shoppingcard)
        {
            Logger       = logger;
            ShoppingCard = shoppingcard;
        }

        public ILogger Logger                           { get; set; }
        public IShoppingCartRepository ShoppingCard     { get; set; }
    }

}
