using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsm.Services.Component.Requisitions.Api
{
    public interface ISurveyRepository
    {

        /// <summary>
        /// 
        /// </summary>
        int TEACHER_GUIDE_CD_OPTION_O1 { get;}

        /// <summary>
        /// 
        /// </summary>
        int TEACHER_GUIDE_CD_OPTION_O2 { get;}

        /// <summary>
        /// 
        /// </summary>
        DateTime EffectiveFrom { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime ExpiresOn { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookYear"></param>
        void LoadStandardsAndNorms(string bookYear);

        /// <summary>
        /// 
        /// </summary>
        string SurveyId { get;}

        /// <summary>
        /// 
        /// </summary>
        string ConsortiumGroupId { get; }
    }
}
