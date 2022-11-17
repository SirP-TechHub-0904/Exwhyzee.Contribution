using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Contribution.Domain.Enums
{
    public enum NotificationType
    {
        [Description("NotDefind")]
        NotDefind = 0,
        [Description("SMS")]
        SMS = 1,

        [Description("Email")]
        Email = 2


    }
}
