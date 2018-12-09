using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsm.Services.Component.Requisitions.Services
{
    using Api;
    using DoE.Lsm.Data.Repositories;

    public class Norms : INorms
    {

        public int teacher_Guide_Cd_Option_001 = 0;
        public int teacher_Guide_Cd_Option_002 = 0;

        public void LoadNorms(string bookYear)
        {
           int.TryParse(_repositoryManager.SnE.GetNorm(nameof(teacher_Guide_Cd_Option_001), bookYear), out teacher_Guide_Cd_Option_001);
           int.TryParse(_repositoryManager.SnE.GetNorm(nameof(teacher_Guide_Cd_Option_002), bookYear), out teacher_Guide_Cd_Option_002);
        }

        public int TEACHER_GUIDE_CD_OPTION_O1
        { get
            { return teacher_Guide_Cd_Option_001;}
        }

        public int TEACHER_GUIDE_CD_OPTION_O2
        {
            get
            { return teacher_Guide_Cd_Option_002;}
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

        #region Helpers 
        protected readonly IRepositoryStoreManager _repositoryManager;

      

        public Norms(IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;

            LoadNorms(repositoryManager.SnE.BookYear);
        }
        #endregion
    }
}
