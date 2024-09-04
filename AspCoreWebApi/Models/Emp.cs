using System.ComponentModel.DataAnnotations;

namespace AspCoreWebApi.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Department{ get; set; }
        public string? Salary { get; set; }
    }
}
