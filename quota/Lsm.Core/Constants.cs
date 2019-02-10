using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Core.Constants
{

    public enum ConditionFlavor
    {
        Equal,
        GreaterThan,
        LessThan
    }


    public enum VettingOutcome : int
    {
        Passed = 1,
        Failed = 0
    }

    public static partial class GlobalCacheKeys
    {
        public readonly static string USER_ID = "USER_ID";
        public readonly static string REQUISITION_INSTANCE_ID = "REQUISITION_INSTANCE_ID";
    }


    public static partial class GlobalCacheKeys
    {
        public readonly static string SHOPPING_CART = "SHOPPING_CART";
    }


    public static class LocalizationConstants
    {

        public const string LP_DEFAULT = "LP_DEFAULT";

        public const string LP_CAPRICORN = "LP_CAPRICORN";

        public const string LP_WATERBURG = "LP_WATERBURG";

        public const string LP_VHEMBE = "LP_VHEMBE";
    }



}