using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize]

    public class DetailsModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;
        
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public DetailsModel(
            UserManager<Profile> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
           
            _context = context;
        }


        public Profile Profile { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profile = await _userManager.FindByIdAsync(id);

            if (Profile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
