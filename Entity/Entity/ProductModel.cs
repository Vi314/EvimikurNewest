﻿using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity;

public class ProductModel : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string? ProductName { get; set; }

    [Required]
    [MaxLength(2000)]
    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    [Range(0, 10)]
    public float? LooksGrade { get; set; }

    [Range(0, 10)]
    public float? UsabilityGrade { get; set; }

    [Range(0, 10)]
    public float? FunctionalityGrade { get; set; }

    [Range(0, 10)]
    public float? InnovativeGrade { get; set; }

    [Range(0, 10)]
    public float? PriceAdvantageGrade { get; set; }

    [Range(0, 10)]
    public float? PotentialSalesGrade { get; set; }

    public List<SaleModel> Sales { get; set; }
    public CategoryModel? Category { get; set; }
}