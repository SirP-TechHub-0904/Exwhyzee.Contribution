using Exwhyzee.Contribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Contribution.Domain.Models
{
    public class GaurantorAccount
    {
        public long Id { get; set; }
        public string ProfileId { get; set; }
        public Profile Profile { get; set; }
        public bool Appoved { get; set; }
        public bool GaurantorSigned { get; set; }
        public string? GaurantorId { get; set; }
        public Profile Gaurantor { get; set; }
        public GurantorStatus GurantorStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
