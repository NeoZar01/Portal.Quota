namespace DoE.Lsm.Web.Services.Api
{
    using Lsm.Web.Models;
    using System;
    using Validations;
    using Validations.Api;

    [Serializable]
    public abstract class BaseViewModel : GroupPolicyClaims
    {
        public string _modelKey;

        public BaseViewModel(string name)
        {
            this._modelKey = name;
        }
    }
}
