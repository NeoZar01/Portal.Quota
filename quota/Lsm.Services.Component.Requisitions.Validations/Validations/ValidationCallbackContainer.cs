using System;

namespace DoE.Lsm.Web.Services.Validations
{
    using Api;
    using Data.Repositories;
    using Core.Constants;
    using ShoppingCart.Norms.Validations.Exceptions;

    using static Core.Constants.VettingOutcome;

    public partial class ValidationCallbackProvider : IValidationCallbackProvider
    {

        public ValidationCallbackProvider()
        {
        }

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

        public string GroupPolicyValidator(string entityId, string modelKey)
        {

            var access = VettingOutcome.Failed;

            return  access.ToString();
        }

        #region Helpers
        protected readonly IUnitOfWork _repositoryManager;
        public ValidationCallbackProvider(IUnitOfWork repositoryManager)
        { this._repositoryManager = repositoryManager; }
        #endregion
    }

    #region RequisitionsSurveysCallbacks
    public partial class ValidationCallbackProvider {

        public string RequisitionsSurveysExpiryDateValidationCallback(DateTime expiresOn, string surveyId, string entityId)
        {
            if (DateTime.Today > expiresOn) return "INVALID";

            return RequisitionsSurveysExpiryDateValidationCallback(surveyId, entityId, expiresOn);
        }

        public string RequisitionsSurveysExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn)
        {
            return null; // _repositoryManager.SnE.IsSurveyEntityInstalled(surveyId, entityId, expiresOn) ? "VALID" : "INVALID";
        }

    }
    #endregion

}