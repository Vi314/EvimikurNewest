﻿using Entity.Base;
using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity;

public class SupplierModel : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string? CompanyName { get; set; }

    [Range(0, 100)]
    public int? SupplierGrade { get; set; }

    public ApprovalState? ApprovalState { get; set; } = Enum.ApprovalState.NotApproved;
}