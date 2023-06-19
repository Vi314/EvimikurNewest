using Entity.Base;
using Entity.Enum;
using Entity.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity;

public class SupplierModel : BaseModel
{
    [Required]
    [MaxLength(100)]
    public string? CompanyName { get; set; }
    [Range(0, 100)]
    public int? SupplierGrade { get; set; }
    public ApprovalState? ApprovalState { get; set; } = Enum.ApprovalState.NotApproved;
    public int UserId { get; set; }
    
    public AppUser User { get; set; }
}