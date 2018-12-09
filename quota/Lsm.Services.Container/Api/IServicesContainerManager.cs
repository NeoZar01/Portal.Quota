namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCart.Api;


    /// <summary>
    /// 
    /// </summary>
    public interface IServicesContainerManager
    {

        /// <summary>
        /// 
        /// </summary>
        IShoppingCartRepository ShoppingCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
 //       RepositoryStore RepositoryStoreService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ILogger Logger { get; set; }

    }
}
