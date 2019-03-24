using System;

namespace DoE.Quota.Web.Services.Validations
{
    using Api;
    using ShoppingCart.Norms.Validations.Exceptions;

    using Core.Globals;
    using Core.Validation;
    using Core.Repositories.Contracts;

    using static DoE.Core.Globals.VettingOutcome;

    public partial class ValidationCallbacksHandler : ValidationCallbackProvider, IValidationCallbacksHandler
    {
        #region Constructor
            protected readonly IUnitofWork _uow;
            public ValidationCallbacksHandler() {}
            public ValidationCallbacksHandler(IUnitofWork uow)  { this._uow = uow; }
        #endregion

        public VettingOutcome LearnerGuideQuotaValidationCallback(int category, int teacherCount, int quantity, int quota)
        {
            try
            {
                if (quantity > quota)
                {
                    throw new LearnerGuideException("You cannot order more books than the number of learners enrolled in your subject");
                }
                return Passed;
            }
            catch
            {
                return Failed;
            }
        }
        public VettingOutcome TeacherGuideQuotaCheckCallback(int quantity, ref int quota, int category, int teacherCount , int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02)
        {
            try
            {

                if (category == (int)teacher_guide_cd_option_x01 || category == (int)teacher_guide_cd_option_x02)
                {
                    if (quantity > teacherCount)
                    {
                        throw new TeacherGuideNormsException("You can only make orders based on the number of teachers assigned a subject."); //throw a custom 
                    }
                }

                var policyResults =  LearnerGuideQuotaValidationCallback(category, teacherCount , quantity , quota);
                            quota = teacherCount;
                return policyResults;
            }
            catch
            {
                return Failed;
            }
        }
    }


    public partial class ValidationCallbacksHandler
    {

        public string ValidateExpiryDate(DateTime expiresOn, string surveyId, string entityId)
        {
            if (DateTime.Today > expiresOn) return "INVALID";
            return ExpiryDateValidationCallback(surveyId, entityId, expiresOn);
        }

        public string ExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn)
        {
            return null; // _repositoryManager.SnE.IsSurveyEntityInstalled(surveyId, entityId, expiresOn) ? "VALID" : "INVALID";
        }

    }


}