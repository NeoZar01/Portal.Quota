using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Services.Models
{
    using Api;
    using Core.Constants;

    using Validations;
    using Validations.Rules;
    using Component.Cache.Proxies;
    using Validations.Api;

    public sealed partial class ShoppingCartViewModel : BaseViewModel
    {

        private readonly GroupPolicyValidationRules pageRightsValidator = new GroupPolicyValidationRules();

        public ShoppingCartViewModel(string name): base(name) {}

        public static explicit operator ShoppingCartViewModel(ShoppingCardModelProxy model)
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

        public string ModelStatus { get; set; }
    }
}