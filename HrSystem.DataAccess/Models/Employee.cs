using HrSystem.DataAccess.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HrSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required Please Enter Values")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Last Name is Required Please Enter Value")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Display Name is Required Please Enter Value")]
        [DisplayName("Display Name")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string DisplayName { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email !!")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Range(1000, 19000, ErrorMessage = "Enter a value between 1000 and 19000")]
        [Required(ErrorMessage = "Salary is Required Please Enter Value")]
        public decimal Salary { get; set; }
        public DateTime DateOfJoin { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int? Dno { get; set; }
        public string JobTitle { get; set; }
        [ForeignKey("Dno")]
        [InverseProperty("Employees")]
        [JsonIgnore]
        public virtual Department? DnoNavigation { get; set; }
        [InverseProperty("MGRSSNNavigation")]
        [JsonIgnore]
        public virtual ICollection<Department>? Departments { get; set; }


    }
}
