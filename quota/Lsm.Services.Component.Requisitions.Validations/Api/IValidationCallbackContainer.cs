using System;

namespace DoE.Lsm.ShoppingCart.Norms.Validations.Api
{
    using Core.Constants;

    ///<summary>
    ///   This interface contains an abstract of what the Quota Validation Run 
    ///<summary>
    public interface IValidationCallbackContainer
    {

        /**
         *  Validate Teacher guide policy against the thrown category codes.  
         */
        ///<summary>  Validate Teacher guide policy against the thrown category codes.
        ///	   <exception cref='ShoppingCard.Validation.Exceptions.LearnerGuideException'> If this norm is broken this exception will be thrown </exception>
        ///  <param name="x">  
        ///            Category code on the item being validated.
        ///     <example>
        ///       <option value ='21'> Teacher Guide 		    </option>
        ///       <option value ='22'> Teacher Reference Book	</option>        
        ///     </example>
        ///	</param>
        ///  <param name="y"> Quota</param>
        ///  <param name="z"> Quota </param>
        ///<summary>
        VettingOutcome TeacherGuideQuotaCheckCallback(int quantity, ref int quota, int category, int teacherCount, int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="teacherCount"></param>
        /// <param name="quantity"></param>
        /// <param name="quota"></param>
        /// <returns></returns>
        VettingOutcome LearnerGuideQuotaValidationCallback(int category, int teacherCount, int quantity, int quota);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expiresOn"></param>
        /// <returns></returns>
        string RequisitionsSurveysExpiryDateValidationCallback(DateTime expiresOn,string surveyId, string entityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="entityId"></param>
        /// <param name="expiresOn"></param>
        /// <returns></returns>
        string RequisitionsSurveysExpiryDateValidationCallback(string surveyId, string entityId, DateTime expiresOn);
    }
}
