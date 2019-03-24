using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Quota.Repositories.Data.Models
{
    public class Survey
    {
        public string    BookYear           { get; set; }
        public string    SurveyId           { get; set; }
        public DateTime  ExpiresOn          { get; set; }
        public DateTime  EffectiveDate      { get; set; }
        public int[]     TeacherGuideCodes  { get; set; }
    }
}
