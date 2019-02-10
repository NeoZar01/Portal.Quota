using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Core
{
    public static class GlobalFunctions
    {
        public static int RemainingDays(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate == null) throw new ArgumentNullException("firstDate");
            if (secondDate == null) throw new ArgumentNullException("secondDate");

            try
            {
                var remDays = secondDate.Subtract(firstDate).Days;
                return remDays < 0 ? 0 : remDays;
            }
            catch { return 0; };
        }
    }
}
