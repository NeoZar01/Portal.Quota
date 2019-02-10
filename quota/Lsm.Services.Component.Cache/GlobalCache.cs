using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoE.Lsm.Web.Models;
using DoE.Lsm.Web.Services.Api;

namespace DoE.Lsm.Web.Services.Web.Session.Cache
{

    public class GlobalCache : IGlobalCache
    {

        private Dictionary<string, object> cache = new Dictionary<string, object>();

        public void AddItem<TModel>(string key, TModel item)
        {
            cache.Add(key, item);
        }

        public TModel Get<TModel>(string key)
        {
            object item = null;
            cache.TryGetValue(key , out item);
            return (TModel)item;
        }

        public void RefreshItem<TModel>(string key , TModel item)
        {
            cache.Remove(key);
            cache.Add(key, item);
        }

        public void RemoveItem<TModel>(string key)
        {
            cache.Remove(key);
        }


    }
}
