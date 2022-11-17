using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Contribution.Domain.Enums
{
    public enum UserStatus
    {
        [Description("NONE")]
        NONE = 0,
        [Description("Account")]
        Account = 2,
        [Description("Gaurantor")]
        Gaurantor = 3,
    }
}
