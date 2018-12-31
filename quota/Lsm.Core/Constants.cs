using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Core.Constants
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

}