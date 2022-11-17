using Exwhyzee.Contribution.Domain.Enums;

namespace Exwhyzee.Contribution.Domain.Models
{
    public class LoanPaymentHistory
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public long LoanId { get; set; }
        public Loan Loan { get; set; }

    }
}
