using Entity.Base;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConnectionEntity;

public class SalesAndProductsModel:BaseDetailsModel
{
    [ForeignKey("Sale")]
    public new int HeaderId { get; set; }
    [ForeignKey("Product")]
    public new int DetailId { get; set; }

    public string PH_STRINGPROP { get; set; } = string.Empty;
    public int PH_INTPROP { get; set; } = 0;

    public SaleModel Sale { get; set; } = new();
    public ProductModel Product { get; set; } = new();
}
