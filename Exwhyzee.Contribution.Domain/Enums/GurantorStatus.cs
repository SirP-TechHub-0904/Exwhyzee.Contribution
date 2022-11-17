using System.ComponentModel;

namespace Exwhyzee.Contribution.Domain.Enums
{

    public enum GurantorStatus
    {
        [Description("NONE")]
        NONE = 0,
        [Description("Loan")]
        Loan = 2,
        [Description("Contribution")]
        Contribution = 3

    }
}
