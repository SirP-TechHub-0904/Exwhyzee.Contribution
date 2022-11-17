using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Contribution.Domain.Enums
{
    public enum NotificationStatus
    {
        [Description("NotDefind")]
        NotDefind = 0,
        [Description("Sent")]
        Sent = 1,

        [Description("NotSent")]
        NotSent = 2,


    }
}
