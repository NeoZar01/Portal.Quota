using System;

namespace DoE.Quota.Web.Services.Validations.Api
{
    using Core.Globals;
    using Core.Validation.Api;

    public interface IValidationCallbacksHandler  : IValidationCallbackProvider
    {

        string ValidateExpiryDate(DateTime expiresOn,string surveyId, string entityId);
        string ExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn);

        VettingOutcome LearnerGuideQuotaValidationCallback(int category, int teacherCount, int quantity, int quota);
        VettingOutcome TeacherGuideQuotaCheckCallback(int quantity, ref int quota, int category, int teacherCount, int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02);

    }
}
