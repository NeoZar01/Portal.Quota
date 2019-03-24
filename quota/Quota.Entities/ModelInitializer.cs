using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Quota.Entities
{
    using Core.Models.Common;
    using Web.Models;

    public static class ModelInitializerExtensions
    {

        public static IModel Get<M>(this IModel model, string modelKey) where M : IModel
        {
            SchoolHomePageViewModel vmodel = null;

            if (model is SchoolHomePageViewModel)
            {
                vmodel.SchoolName = "SchoolName";

                model = vmodel;
            }

            return model;
        }

        public static IModel Or<M>(this IModel model, string modelKey) where M : IModel
        {
            AdmnistratorHomeViewModel vmodel = null;

            if (model is AdmnistratorHomeViewModel)
            {
                model = vmodel;
            }
            return model;
        }
    }
}
