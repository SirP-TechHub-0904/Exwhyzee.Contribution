using Exwhyzee.Contribution.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "mSuperAdmin")]

    public class PermissionModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Profile> _signInManager;
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;



        public PermissionModel(
            UserManager<Profile> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Profile> signInManager,
            Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        public IList<string> Roles { get; set; }
        public IList<string> UserRoles { get; set; }
        public IList<string> RemainingUserRoles { get; set; }

        [BindProperty]
        public Profile Profile { get; set; }
      

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profile = await _userManager.FindByIdAsync(id);
 Roles = await _roleManager.Roles/*.Where(x => x.Name != "mSuperAdmin")*/.Select(x => x.Name).ToListAsync();


            UserRoles = await _userManager.GetRolesAsync(Profile);
           

                var RemainingRoles = Roles.Except(UserRoles);
            RemainingUserRoles = RemainingRoles.ToList();

            if (Profile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string UserId)
        {
             var role = await _roleManager.FindByIdAsync(id);
            var user = await _userManager.FindByIdAsync(UserId);
            var checkuserroles = await _userManager.IsInRoleAsync(user, role.Name);
            if (checkuserroles == true)
            {
                try
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                    TempData["aasuccess"] = "permission update successfully";
                }
                catch (Exception d) {

                    TempData["aaerror"] = "Unable to update permission";
                }
            }
            else
            {
                try
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                    TempData["aasuccess"] = "permission update successfully";
                }
                catch (Exception d) {

                    TempData["aaerror"] = "Unable to update permission";
                }
            }


            return RedirectToPage("./Permission", new { uid = user.Id, fullname = user.Fullname });
        }
           
    }
}
