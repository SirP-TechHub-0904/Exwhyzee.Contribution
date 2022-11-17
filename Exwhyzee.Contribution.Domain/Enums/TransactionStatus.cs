using System.ComponentModel;

namespace Exwhyzee.Contribution.Domain.Enums
{

    public enum TransactionStatus
    {
        [Description("NONE")]
        NONE = 0,
        [Description("Paid")]
        Paid = 2,
        [Description("Pending")]
        Pending = 3,
        [Description("Canceled")]
        Canceled = 4

    }
}
