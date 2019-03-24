
using System;

namespace DoE.Quota.Web.Services.Validations.Rules
{
    using Api;
    using Core.Validation.Api;

    public class RequisitionsValidationRule
    {

        public delegate string RequisitionsSurveysValidationCallback(DateTime expiresOn, string surveyId, string entityId);

        public RequisitionsSurveysValidationCallback RequisitionsSurveysCheck;

        public void ValidateRequisitions(IValidationCallbacksHandler callback, DateTime expiresOn, string surveyId, string entityId, out string output)
        {
            RequisitionsSurveysCheck = callback.ValidateExpiryDate;
            output = RequisitionsSurveysCheck(expiresOn, surveyId , entityId);
        }
    }
}
