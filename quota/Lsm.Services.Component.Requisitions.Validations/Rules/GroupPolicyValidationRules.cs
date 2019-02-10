using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Services.Validations.Rules
{
    using Api;

    public class GroupPolicyValidationRules
    {

        private delegate string GroupPolicyCallback(string entityId, string modelKeys);

        private GroupPolicyCallback GroupPolicyProvider;

        public void ValidateGroupPolicy(IValidationCallbackProvider callback, string entityId, string modelKeys, out string output)
        {
            GroupPolicyProvider = callback.GroupPolicyValidator;
            output = GroupPolicyProvider(entityId, modelKeys);
        }
    }
}
