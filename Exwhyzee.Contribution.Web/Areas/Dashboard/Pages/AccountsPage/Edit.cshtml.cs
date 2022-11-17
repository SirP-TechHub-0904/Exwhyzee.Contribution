using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.AccountsPage
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly SignInManager<Profile> _signInManager;
        private readonly UserManager<Profile> _userManager;
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;



        public EditModel(
            UserManager<Profile> userManager,
            SignInManager<Profile> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        [BindProperty]
        public Profile Profile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/Notfound", new { area = "" });
            }

            Profile = await _userManager.FindByIdAsync(id);

            if (Profile == null)
            {
                return RedirectToPage("/Notfound", new {area=""});
            }

            ViewData["StateId"] = new SelectList(_context.States, "StateName", "StateName");
            
            return Page();
        }
        public List<SelectListItem> LgaList { get; set; }

        public async Task<JsonResult> OnGetLGA(string id)
        {

            List<LocalGoverment> lga = new List<LocalGoverment>();

            var query = await _context.LocalGoverments
                .Include(x => x.States)
                .Where(x => x.States.StateName == id).ToListAsync();


            LgaList = query.Select(a =>
                                new SelectListItem
                                {
                                    Value = a.LGAName,
                                    Text = a.LGAName
                                }).ToList();
            return new JsonResult(LgaList);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var updateparticipant = await _userManager.FindByIdAsync(Profile.Id);
            try
            {
                updateparticipant.Surname = Profile.Surname;
                updateparticipant.FirstName = Profile.FirstName;
                updateparticipant.OtherName = Profile.OtherName;
                updateparticipant.Title = Profile.Title;
                updateparticipant.LGA = Profile.LGA;
                updateparticipant.State = Profile.State;
                updateparticipant.ContactAddress = Profile.ContactAddress;
                updateparticipant.HomeAddress = Profile.HomeAddress;
                updateparticipant.AltPhoneNumber = Profile.AltPhoneNumber;
                updateparticipant.GenderStatus = Profile.GenderStatus;
                updateparticipant.MaritalStatus = Profile.MaritalStatus;
                updateparticipant.ReligionStatus = Profile.ReligionStatus;
                updateparticipant.UserStatus = Profile.UserStatus;
                updateparticipant.DOB = Profile.DOB;
                updateparticipant.Bio = Profile.Bio;

                updateparticipant.EmergencyContactEmail = Profile.EmergencyContactEmail;
                updateparticipant.EmergencyContactPhone = Profile.EmergencyContactPhone;
                updateparticipant.EmergencyContactName = Profile.EmergencyContactName;

                await _userManager.UpdateAsync(updateparticipant);
                TempData["aasuccess"] = "Updated successfully";
            }
            catch (Exception)
            {
                ViewData["StateId"] = new SelectList(_context.States, "StateName", "StateName");

                TempData["aaerror"] = "Unable to update account";
                return Page();
            }

            return RedirectToPage("./Index");
        }

       
    }
}
