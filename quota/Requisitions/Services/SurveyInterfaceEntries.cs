using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsm.Services.Component.Requisitions.Services
{
    using Api;
    using DoE.Lsm.Data.Repositories;

    public class SurveyInterfaceEntries : ISurveyInterfaceEntries
    {

        public int TEACHER_GUIDE_CD_001 = 0;
        public int TEACHER_GUIDE_CD_002 = 0;

        public string surveyId          = "";
        public string consortiumGroupId = "";


        public void LoadStandardsAndNorms(string bookYear)
        {
           int.TryParse(_repositoryManager.SnE.GetNorm("BOOKSQUOTA", nameof(TEACHER_GUIDE_CD_001), bookYear), out TEACHER_GUIDE_CD_001);
           int.TryParse(_repositoryManager.SnE.GetNorm("BOOKSQUOTA", nameof(TEACHER_GUIDE_CD_002), bookYear), out TEACHER_GUIDE_CD_002);
        }

        public int TEACHER_GUIDE_CD_OPTION_O1
        { get
            { return TEACHER_GUIDE_CD_001;}
        }

        public int TEACHER_GUIDE_CD_OPTION_O2
        {
            get
            { return TEACHER_GUIDE_CD_002;}
        }

        public DateTime EffectiveFrom
        {
            get
            { return _repositoryManager.SnE.EffectiveFrom; }
        }

        public DateTime ExpiresOn
        {
            get
            { return _repositoryManager.SnE.ExpiresOn; }
        }

        public string SurveyId
        {
            get
            {   return surveyId;}
        }

        public string ConsortiumGroupId
        {
            get
            { return consortiumGroupId; }
        }

        #region Helpers 
        protected readonly IRepositoryStoreManager _repositoryManager;

      

        public SurveyInterfaceEntries(IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;

            LoadStandardsAndNorms(repositoryManager.SnE.BookYear);
        }
        #endregion
    }
}
