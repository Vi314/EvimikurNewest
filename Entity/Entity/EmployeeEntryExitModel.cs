using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class EmployeeEntryExitModel : BaseModel
    {
        [Required]
        public int? EmployeeId { get; set; }

        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        public EmployeeModel Employee { get; set; } = new();
    }
}