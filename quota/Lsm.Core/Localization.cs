using System;

namespace DoE.Lsm.Web.Core.Localization
{

    using Constants;

    public static class Localization
    {

        public static string ConvertToFormalFormat(this DateTime sourceDatetime, string culture) {
            if (sourceDatetime == null) throw new ArgumentNullException("sourceDate");

            //return DateTime.ParseExact(sourceDatetime.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(string.IsNullOrEmpty(format) ? "yyyy" : format);
           
            switch (culture)
            {
                case LocalizationConstants.LP_CAPRICORN:
                    return Convert.ToDateTime(sourceDatetime).ToString("dd MMMM yyyy");
                default:
                    return Convert.ToDateTime(sourceDatetime).ToString("MMMM dd, yyyy");
            }
        }
    }
}
