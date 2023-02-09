using System.ComponentModel.DataAnnotations;

namespace EmployeePerformanceTracker1.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Progress Description")]
        public string ProgressDescription { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
