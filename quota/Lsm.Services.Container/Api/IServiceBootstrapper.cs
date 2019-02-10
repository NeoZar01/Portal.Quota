namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCart.Api;

    public interface IServiceBootstrapper
    {
        IShoppingCartRepository ShoppingCard { get; set; }
        ILogger                 Logger { get; set; }

    }
}
