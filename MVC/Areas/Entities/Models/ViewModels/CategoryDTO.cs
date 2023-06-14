﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class CategoryDto : BaseDto
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string Name { get; set; } = string.Empty;

        [DefaultValue("Açıklama Yok")]
        [MaxLength(2000, ErrorMessage = ErrorMessages.toolong2000)]
        public string? Description { get; set; }
    }
}