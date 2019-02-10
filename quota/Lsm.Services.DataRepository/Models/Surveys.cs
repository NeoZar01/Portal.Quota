using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.Models
{
    public class Surveys
    {
        public string BookYear { get; set; }
        public string SurveyId { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
