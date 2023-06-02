using Entity.Base;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity;

public class SupplierModel:BaseEntity
{
	[Required]
	[MaxLength(100)]
	public string? CompanyName { get; set; }
	[Range(0,100)]
	public int? SupplierGrade { get; set; }
	public ApprovalState? ApprovalState { get; set; } = Enum.ApprovalState.NotApproved;
}
