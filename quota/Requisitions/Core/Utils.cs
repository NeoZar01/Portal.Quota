using DoE.Lsm.Web.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requisitions.Core
{

    public class UtilCallbacksContainer : IUtilCallbacksContainer
    {

        public static class QuotaExpressions
        {

            public delegate object RazorConditionCallBack(params string[] parameters);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="conditionFlavour"></param>
            /// <param name="callBack"></param>
            /// <param name="operand"></param>
            /// <param name="sucessfulResults"></param>
            /// <param name="failedResults"></param>
            /// <returns></returns>
            public static string IIF(ConditionFlavor conditionFlavour, RazorConditionCallBack callBack, object operand, string sucessfulResults, string failedResults)
            {
                switch (conditionFlavour)
                {
                    case ConditionFlavor.Equal:
                        return sucessfulResults;
                    default:
                        return failedResults;
                }
            }


        }
    }
}
