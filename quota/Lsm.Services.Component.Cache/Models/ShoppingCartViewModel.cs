using System;

namespace DoE.Quota.Web.Services.Models
{

    using Core.Web.Models;
    using Core.Validation.Rules;
    using Component.Cache.Proxies;

    public sealed partial class ShoppingCartViewModel : BaseViewModel
    {
        private readonly GroupPolicyValidationRules groupPolicyValidationRule = new GroupPolicyValidationRules();

        public ShoppingCartViewModel(string name): base(name) {}

        public static explicit operator ShoppingCartViewModel(ShoppingCartInstance model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                ShoppingCartViewModel proxy = new ShoppingCartViewModel("");
                                      proxy.ModelStatus = model.ModelStatus;
                return proxy;
            }
            catch
            {
                return null;
            }
        }

        public string ModelStatus   { get; set; }
    }
}