using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SerialNumber { get; set; } 
    }
}
