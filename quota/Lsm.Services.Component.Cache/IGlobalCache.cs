using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Services.Web.Session.Cache
{
    using Api;
    using Lsm.Web.Models;

    public interface IGlobalCache
    {
        void AddItem<TModel>(string key, TModel item);
        void RemoveItem<TModel>(string key);
        void RefreshItem<TModel>(string key, TModel item);
        TModel Get<TModel>(string key);
    }
}