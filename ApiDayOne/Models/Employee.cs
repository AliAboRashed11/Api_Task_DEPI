using ApiDayOne.Validation;
using System.ComponentModel.DataAnnotations;
namespace ApiDayOne.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(10,ErrorMessage="{0} Length must be {1} maximum")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Range(27,30,ErrorMessage ="{0} must be between {1} and {2}")]
        public int Age { get; set; }
        public double Salary { get; set; }
        [MustBeInThePast]
        public DateTime CreatedOn { get; set; }
    }
}
