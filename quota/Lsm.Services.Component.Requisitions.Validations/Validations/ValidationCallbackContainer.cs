namespace DoE.Lsm.ShoppingCart.Norms.Validations
{
    using Api;
    using Rules;
    using Exceptions;
    using Core.Constants;

    using static Core.Constants.VettingOutcome;
    using System;
    using Data.Repositories;

    public partial class ValidationCallbackContainer : IValidationCallbackContainer
    {



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

        #region Helpers
        protected readonly IRepositoryStoreManager _repositoryManager;
        public ValidationCallbackContainer(IRepositoryStoreManager repositoryManager)
        { this._repositoryManager = repositoryManager; }
        #endregion
    }

    #region RequisitionsSurveysCallBackMethods 
    public partial class ValidationCallbackContainer {

        public string RequisitionsSurveysExpiryDateValidationCallback(DateTime expiresOn, string surveyId, string entityId)
        {
            if (DateTime.Today > expiresOn) return "INVALID";

            return RequisitionsSurveysExpiryDateValidationCallback(surveyId, entityId, expiresOn);
        }

        public string RequisitionsSurveysExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn)
        {
            return _repositoryManager.SnE.IsSurveyEntityInstalled(surveyId, entityId, expiresOn) ? "VALID" : "INVALID";
        }

    }
    #endregion



}