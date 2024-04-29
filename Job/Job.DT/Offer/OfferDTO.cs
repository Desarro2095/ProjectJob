using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DT.Offer
{
    public class OfferDTO
    {
        public int OfferId { get; set; }
        public string OfferDescription { get; set; }
        public int CurrentVacancy { get; set; }
        public int EmployerId { get; set; }
        public string Empresa { get; set; } = string.Empty;
    }
}
