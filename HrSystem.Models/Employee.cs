using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Display Name")]
        [Required(ErrorMessage = "Display Name is Required")]
        public string DisplayName { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email !!")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Range(1000, 19000)]
        public decimal Salary { get; set; }
        public DateTime DateOfJion { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string JobTitle { get; set; }
        public int PhoneNumberID { get; set; }
        [ForeignKey("PhoneNumberID")]

        public ICollection<EmployeePhoneNumbers> EmployeePhoneNumbers { get; set; }

    }
}
