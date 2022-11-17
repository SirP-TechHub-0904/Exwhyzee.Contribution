using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]

    public class UpdateEmailModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;

        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public UpdateEmailModel(
            UserManager<Profile> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;

            _context = context;
        }

        [BindProperty]
        public Profile Profile { get; set; }

        [BindProperty]
        public string NewEmail { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/Notfound", new { area = "" });
            }

            Profile = await _userManager.FindByIdAsync(id);

            if (Profile == null)
            {
                return RedirectToPage("/Notfound", new { area = "" });
            }


            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var updateparticipant = await _userManager.FindByIdAsync(Profile.Id);

            var email = await _userManager.GetEmailAsync(updateparticipant);
            if (NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(updateparticipant);
                var code = await _userManager.GenerateChangeEmailTokenAsync(updateparticipant, NewEmail);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                //var xcode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                var result = await _userManager.ChangeEmailAsync(updateparticipant, NewEmail, code);
                if (!result.Succeeded)
                {
                    TempData["aaerror"] = "Error changing email.";
                    return Page();
                }
                TempData["aasuccess"] = "Email Updated successfully";
                return RedirectToPage("./Details", new { id = Profile.Id });
            }
            TempData["aaerror"] = "Error changing email or Email is already used.";


            return RedirectToPage("./Details", new { id = Profile.Id });
        }

    }
}
