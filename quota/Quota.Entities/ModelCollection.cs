using System;
using System.Collections.Generic;

using Core.Globalization;

namespace DoE.Quota.Entities
{
    using Web.Models;

    using Core.Identity.Claims;
    using Core.Models.Common;

    public class ModelCollection : IDisposable
    {

        private static Dictionary<string, IModel> modelDictionary = new Dictionary<string, IModel>();

        private static ModelCollection _instance;
        private static object key = new object();

        public static ModelCollection InitializeCollector()
        {

            lock (key)
            {
                if (_instance == null)
                {
                    _instance = new ModelCollection();
                }

                modelDictionary.Add(GroupPolicy.CAN_VIEW_ADMINISTRATION_HOMEPAGE, new AdmnistratorHomeViewModel("_mainpagedashboard_administrator"));
                modelDictionary.Add(GroupPolicy.CAN_VIEW_SCHOOL_HOMEPAGE, new SchoolHomePageViewModel("_mainpagedashboard_administrator"));
            }

            return _instance;
        }

        public void Resolve<TVModel>(string key, out IModel model) where TVModel : IModel
        {
            if(modelDictionary[key] != null)
            {
                model = modelDictionary[key];
            }

            model = null;
        }

        public void Dispose()
        {
            if(_instance !=null)
               _instance = null;

            GC.SuppressFinalize(this);
        }
    }
}
