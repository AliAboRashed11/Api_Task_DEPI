using System.ComponentModel.DataAnnotations;
namespace ApiDayOne.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        //[RegularExpression("^(USA|SA|EGY)")]
        public string Location { get; set; }
    }
}
