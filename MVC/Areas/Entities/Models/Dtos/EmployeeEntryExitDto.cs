﻿using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class EmployeeEntryExitDto : BaseDto
    {
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? EmployeeId { get; set; }

        public DateTime Entry { get; set; } = DateTime.Now;
        public DateTime Exit { get; set; } = DateTime.Now.AddHours(1);
    }
}