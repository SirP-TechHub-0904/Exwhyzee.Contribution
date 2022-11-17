using Exwhyzee.Contribution.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exwhyzee.Contribution.Domain.Models
{
    public class Profile : IdentityUser
    {
        public string? Surname { get; set; }
        public string? FirstName { get; set; }
        public string? OtherName { get; set; }
        public string? Title { get; set; }
        public string? LGA { get; set; }
        public string? State { get; set; }
        public string? ContactAddress { get; set; }
        public string? HomeAddress { get; set; }
        public string? AltPhoneNumber { get; set; }
        public string? Bio { get; set; }
        public GenderStatus GenderStatus { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ReligionStatus ReligionStatus { get; set; }
        public UserStatus UserStatus { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime Date { get; set; }

        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactEmail { get; set; }
        public bool ApproveEmergencyContact { get; set; }

        public string? NextOfKinName { get; set; }
        public string? NextOfKinPhone { get; set; }
        public string? NextOfKinEmail { get; set; }
        public string IPPIS_NO { get; set; }
        public string FileNumber { get; set; }

        public bool ApproveNextOfKin { get; set; }

        public string? Fullname
        {
            get
            {
                return Title + " " + Surname + " " + FirstName + " " + OtherName;
            }
        }
    }
}
