using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity.Identity
{
    public class AppUserRole: IdentityRole<int>
    {
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
