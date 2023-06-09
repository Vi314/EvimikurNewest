﻿using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class EmployeeModel : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Department { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string? EducationLevel { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? FullAddress { get; set; }

        public int? DealerId { get; set; }
        public bool? HasHealthInsurance { get; set; }

        [MaxLength(50)]
        public string? IBAN { get; set; }

        public string? BankBranch { get; set; }

        [MaxLength(50)]
        public string? TCKN { get; set; }

        public DateTime HiredDate { get; set; }

        public DealerModel? Dealer { get; set; }
    }
}