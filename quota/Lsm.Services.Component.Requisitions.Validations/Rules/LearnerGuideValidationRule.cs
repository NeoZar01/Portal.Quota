namespace DoE.Lsm.Web.Services.Validations.Rules
{
    using Api;
    using Core.Constants;

    /**   The LearnerGuideValidationRule class will contains all the norms merged to ordering a learner guides.
     */
    ///<summary>
    ///    The LearnerGuideValidationRule class will contains all the norms merged to ordering a learner guides.
    ///	  <remark>  TOADD a new norm just create a method and  </remark>
    ///	  <see> Facade design patterns on how I managed to accomplish Inversion of Control(IoC)/Loosely coupled applications techniques</see>
    ///	  <seealso>Coding in c# using SOLID Principles</seealso>
    ///<summary>
    public sealed class LearnerGuideValidationRule
    {

        public VettingOutcome output;

        public delegate VettingOutcome LearnerGuidesValidationCallback(int category, int teacherCount, int quantity, int quota);

        public LearnerGuidesValidationCallback LearnerGuideCheck;

        public void ActionLearnerGuideValidationWorker(IValidationCallbackProvider callback, int category, int teacherCount, int quantity, int quota)
        {
            LearnerGuideCheck = callback.LearnerGuideQuotaValidationCallback;
            output = LearnerGuideCheck(category, teacherCount, quantity , quota);
        }
    }
}
