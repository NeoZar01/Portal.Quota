using System;

namespace DoE.Lsm.Web.Services.Validations.Api
{
    using Core.Constants;

    public interface IValidationCallbackProvider
    {

        ///<summary>  Validate Teacher guide policy against the thrown category codes.
        ///	   <exception cref='ShoppingCard.Validation.Exceptions.LearnerGuideException'> If this norm is broken this exception will be thrown </exception>
        ///  <param name="x">Category code on the item being validated.
        /// <example>
        /// <option value ='21'> Teacher Guide 		    </option>
        /// <option value ='22'> Teacher Reference Book	</option>        
        ///	</param>
        ///  <param name="y"> Quota</param>
        ///  <param name="z"> Quota </param>
        ///<summary>
        VettingOutcome TeacherGuideQuotaCheckCallback(int quantity, ref int quota, int category, int teacherCount, int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02);

        VettingOutcome LearnerGuideQuotaValidationCallback(int category, int teacherCount, int quantity, int quota);

        string RequisitionsSurveysExpiryDateValidationCallback(DateTime expiresOn,string surveyId, string entityId);

        string RequisitionsSurveysExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn);

        string GroupPolicyValidator(string entityId, string modelKey);

    }
}
