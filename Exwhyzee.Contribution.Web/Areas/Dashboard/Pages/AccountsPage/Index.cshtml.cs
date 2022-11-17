using Exwhyzee.Contribution.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize]

    public class IndexModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;

        public IndexModel(UserManager<Profile> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable<Profile>? Profile { get;set; }

        public async Task OnGetAsync()
        {
            Profile = _userManager.Users.Where(x => x.Email != "jinmcever@gmail.com").AsQueryable();
            //await Task.Run();
        }
    }
}
