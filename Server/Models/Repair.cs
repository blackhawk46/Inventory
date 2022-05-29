using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Repair
    {
        public int Id { get; set; }
        [Required]
        public Asset Asset { get; set; }
        [Required]
        public DateTime DateBegin   { get; set; }   
        public DateTime? DateEnd { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Detail> Details { get; set; } = new();
        public List<Service> Services { get; set; } = new();
        public string? Description { get; set; } 
    }
}
