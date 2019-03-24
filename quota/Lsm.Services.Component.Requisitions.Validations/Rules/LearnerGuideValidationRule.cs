namespace DoE.Quota.Web.Services.Validations.Rules
{
    using Api;
    using Core.Globals;

    public sealed class LearnerGuideValidationRule
    {

        public VettingOutcome output;

        public delegate VettingOutcome LearnerGuidesValidationCallback(int category, int teacherCount, int quantity, int quota);

        public LearnerGuidesValidationCallback LearnerGuideCheck;

        public void ActionLearnerGuideValidationWorker(IValidationCallbacksHandler callback, int category, int teacherCount, int quantity, int quota)
        {
            LearnerGuideCheck = callback.LearnerGuideQuotaValidationCallback;
            output = LearnerGuideCheck(category, teacherCount, quantity , quota);
        }
    }
}
