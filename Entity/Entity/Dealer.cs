using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Dealer: BaseEntity
    {
        public string? Name { get; set; }
        public string? FullAdress { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
