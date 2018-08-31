using System.ComponentModel.DataAnnotations;

namespace GymManagement.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Mobile { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
    }
}