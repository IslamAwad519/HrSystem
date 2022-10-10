using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Models
{
    public class EmployeePhoneNumber
    {
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
