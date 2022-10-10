using HrSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HrSystem.DataAccess.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MgrId { get; set; }
        [ForeignKey("MgrId")]
        [InverseProperty("Departments")]
        [JsonIgnore]
        public virtual Employee? MGRSSNNavigation { get; set; }
        [InverseProperty("DnoNavigation")]
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
