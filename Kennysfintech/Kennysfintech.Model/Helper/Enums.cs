using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Model.Helper
{

    public enum IOC
    {
        Open=1, 
        Closed=2
    }

    public enum DC
    {
        Debit=1,
        Credit=2
    }

    public enum RecordStatus
    {
        Active = 1,
        Deleted = 0
    }


    public enum Gender
    {
        [Description("E")]
        E,
        [Description("K")]
        K
    }
}
