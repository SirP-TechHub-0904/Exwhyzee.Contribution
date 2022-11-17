using Exwhyzee.Contribution.Domain.Enums;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly SignInManager<Profile> _signInManager;
        private readonly UserManager<Profile> _userManager;
        private readonly ILogger<CreateModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public CreateModel(
            UserManager<Profile> userManager,
            SignInManager<Profile> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult OnGet()
        {

          
            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }

       
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            public string? Surname { get; set; }
            [Display(Name = "First Name")]
            public string? FirstName { get; set; }
            [Display(Name = "Other Name")]
            public string? OtherName { get; set; }
            public string? Title { get; set; }
          
            public string? Sponsor { get; set; }
            public string? PhoneNumber { get; set; }
            public long SECId { get; set; }
            public GenderStatus GenderStatus { get; set; }
            public UserStatus UserStatus { get; set; }
            public string IPPIS_NO { get; set; }
            public string FileNumber { get; set; }


        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var user = new Profile
            {
                UserName = Input.Email,
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                FirstName = Input.FirstName,
                Surname = Input.Surname,
                OtherName = Input.OtherName,
                Title = Input.Title,
                GenderStatus = Input.GenderStatus,
                IPPIS_NO = Input.IPPIS_NO,
                FileNumber = Input.FileNumber,
                Date = DateTime.UtcNow.AddHours(1),
                UserStatus = Input.UserStatus
            };
            Guid pass = Guid.NewGuid();
            var result = await _userManager.CreateAsync(user, pass.ToString().Replace("-", ".") + "XY");

            if (result.Succeeded)
            {
                TempData["aasuccess"] = "Account created successfully";
                return RedirectToPage("./Index");
            }
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            TempData["aaerror"] = messages;
            //
            
            return Page();

        }

      
    }
}
