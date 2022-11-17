using Exwhyzee.Contribution.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exwhyzee.Contribution.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConsentLetter> ConsentLetters { get; set; }
        public DbSet<GaurantorAccount> GaurantorAccounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<LoanPaymentHistory> LoanPaymentHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LocalGoverment> LocalGoverments { get; set; }
    }
}