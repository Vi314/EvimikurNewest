﻿using Entity.Entity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels;

public class SaleDTO : BaseDTO
{
	[Required]
	public DateTime StartDate { get; set; } = DateTime.Now;
    [Required]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public string Description { get; set; } 
	[Required]
	[Range(1, 99, ErrorMessage = "Değer 0 ile 100 arasında olmalı!")]
	public double Discount { get; set; }
	public List<int>? Productids { get; set; }
	public List<int>? Dealerids { get; set; }
	public bool IsForAllDealers { get; set; } = false;
	public bool IsForAllProducts { get; set; } = false;
}
