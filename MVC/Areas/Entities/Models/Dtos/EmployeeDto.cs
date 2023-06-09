﻿using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class EmployeeDto : BaseDto
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string EducationLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(2000, ErrorMessage = ErrorMessages.toolong2000)]
        public string FullAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string Title { get; set; } = string.Empty;

        public string? DealerModel { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? DealerId { get; set; }

        public DateTime HiredDate { get; set; } = DateTime.Now;
    }
}