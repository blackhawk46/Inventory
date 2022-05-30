using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Repair
    {
        public int Id { get; set; }
        [Required]
        public Asset? Imu { get; set; }
        [Required]
        public DateTime DateBegin   { get; set; }   
        public DateTime? DateEnd { get; set; }
        [Required]
        public string Name { get; set; }
        public Detail? Detail { get; set; }
        public Service? Service { get; set; }
        public Double? TotalPrice { get; set; }
        public string? Description { get; set; }
    }
}
