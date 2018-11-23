using System;

namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCard.Api;
    /// <summary>
    /// 
    /// </summary>
    public class Schema : ISchemaRegistry
    {

        /// <summary>
        ///         constructor
        /// </summary>
        /// <param name="logger"></param>
        public Schema(ILogger logger, IShoppingCard shoppingcard)
        {
            //newup the EventLogger from the container
            Logger       = logger;
            //newup the shoppingcard from the container
            ShoppingCard = shoppingcard;
        }

        public ILogger Logger
        { get; set; }

        public IShoppingCard ShoppingCard
        { get; set; }
    }

}
