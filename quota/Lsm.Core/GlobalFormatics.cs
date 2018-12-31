using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsm.Core.Global
{
    public static class GlobalFormatics
    {

        public static string ConvertToFormalFormat(this DateTime sourceDatetime, string format) {
            if (sourceDatetime == null) throw new ArgumentNullException("sourceDate");

            //return DateTime.ParseExact(sourceDatetime.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(string.IsNullOrEmpty(format) ? "yyyy" : format);
            return Convert.ToDateTime(sourceDatetime).ToString("MMMM dd, yyyy");
        }

        public static int RemainingDays(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate == null)   throw new ArgumentNullException("firstDate");
            if (secondDate == null)  throw new ArgumentNullException("secondDate");

            try
            {
              var remDays = secondDate.Subtract(firstDate).Days;
              return remDays < 0 ? 0 : remDays;
            } catch { return 0; };
        }


    }
}
