using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
