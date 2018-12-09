using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Areas.Requisitions.Models
{
    using ShoppingCart.Proxies;

    public sealed partial class ShoppingCartViewModel
    {
        public static explicit operator ShoppingCartViewModel(ShoppingCartProxyModel model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                ShoppingCartViewModel proxy = new ShoppingCartViewModel();
                                      proxy.BookYear    = model.BookYear;
                                      proxy.ModelStatus = model.ModelStatus;
                return proxy;
            }
            catch
            {
                return null;
            }
        }

        public string BookYear { get; set; }

        public string ModelStatus { get; set; }
    }
}