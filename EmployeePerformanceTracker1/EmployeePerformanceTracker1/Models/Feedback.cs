using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerformanceTracker1.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Feedback")]
        public string Comment { get; set; }

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
