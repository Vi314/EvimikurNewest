using Entity.Base;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class Supplier:BaseEntity
	{
		public string? CompanyName { get; set; }
		public int? SupplierGrade { get; set; }
		public ApprovalState? ApprovalState { get; set; } = Enum.ApprovalState.NotApproved;
	}
}
