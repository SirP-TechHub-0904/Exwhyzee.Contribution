using Exwhyzee.Contribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Contribution.Domain.Models
{
    public class ConsentLetter
    {
        public long Id { get; set; }
        public string Letter { get; set; }
        public ConsentLetterStatus ConsentLetterStatus { get; set; }
    }
}
