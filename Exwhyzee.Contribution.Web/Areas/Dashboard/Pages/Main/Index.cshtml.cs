using Exwhyzee.Contribution.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.Main
{
    //[Microsoft.AspNetCore.Authorization.Authorize]

    public class IndexModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public IndexModel(UserManager<Profile> userManager, Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public int Accounts { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }

        public int Gaurantors { get; set; }
        public int GaurantorsMale { get; set; }
        public int GaurantorsFemale { get; set; }
        public int GaurantorsExternal { get; set; }

        public int MonthTotalContribution { get; set; }
        public int MonthTotalAmount { get; set; }
        public int MonthTotalSuccess { get; set; }
        public int MonthTotalPending { get; set; }

        public int AllTotalContribution { get; set; }
        public int AllTotalAmount { get; set; }
        public int AllTotalSuccess { get; set; }
        public int AllTotalPending { get; set; }

        public int MonthLoanApplication { get; set; }
        public int MonthLoanAmmount { get; set; }
        public int MonthLoanSuccess { get; set; }
        public int MonthLoanPending { get; set; }

        public int MonthLoanRedemtion { get; set; }
        public int MonthLoanRedemtionAmmount { get; set; }
        public int MonthLoanRedemtionSuccess { get; set; }
        public int MonthLoanRedemtionPending { get; set; }


        public int GeneralLoanApplication { get; set; }
        public int GeneralLoanAmmount { get; set; }
        public int GeneralLoanSuccess { get; set; }
        public int GeneralLoanPending { get; set; }

        public int GeneralLoanRedemtion { get; set; }
        public int GeneralLoanRedemtionAmmount { get; set; }
        public int GeneralLoanRedemtionSuccess { get; set; }
        public int GeneralLoanRedemtionPending { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
           
            return Page();
        }
    }
}
