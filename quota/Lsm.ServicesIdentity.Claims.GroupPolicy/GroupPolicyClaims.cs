
namespace DoE.Lsm.Web.Services.Validations
{
    using Api;
    using Rules;

    public abstract class GroupPolicyClaims
    {
        string _groupPolicy = "";

        public virtual string GPUpdate(string entityId, string modelKey, IValidationCallbackProvider validationCallback, GroupPolicyValidationRules validationRule)
        {     
            validationRule.ValidateGroupPolicy(validationCallback, entityId, modelKey , out _groupPolicy);
            return _groupPolicy;
        }
    }
}