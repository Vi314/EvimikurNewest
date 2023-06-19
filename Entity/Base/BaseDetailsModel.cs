using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Base;

public class BaseDetailsModel:BaseModel
{
    public int HeaderId { get; set; }
    public int DetailId { get; set; }
}
