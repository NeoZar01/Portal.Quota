using System;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repository.Norms
{
    using Annotations;
    using Repositories;
    using Repositories.EF;

    public interface ISurveysRepository : IRepository<InterfaceSurvey>
   {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisId"></param>
        /// <param name="bookYear"></param>
        /// <returns></returns>
        string GetNorm(string normGroup, string label, string bookYear);

        /// <summary>
        /// 
        /// </summary>
        string BookYear { get; }

        /// <summary>
        /// 
        /// </summary>
        string SurveyId { get; }

        /// <summary>
        /// 
        /// </summary>
        string SurveyCD { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime ExpiresOn { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime EffectiveFrom { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="entityId"></param>
        /// <param name="expiresOn"></param>
        /// <returns></returns>
        bool IsSurveyEntityInstalled(string surveyId, string entityId, DateTime expiresOn);
    }
}