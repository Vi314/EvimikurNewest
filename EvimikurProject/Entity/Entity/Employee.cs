using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Employee:BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
        public string? EducationLevel { get; set; }
        public string? FullAddress { get; set; }
        public int? DealerId { get; set; } 
        public int? DistrictId { get; set; }
        public bool? HasHealthInsurance { get; set; }

        public Dealer? Dealer { get; set; }
        public District? District { get; set; }
    }
}
