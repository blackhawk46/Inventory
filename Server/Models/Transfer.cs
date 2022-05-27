using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public Asset? Asset { get; set; }   
        [Required]
        public Place PlaceOld { get; set; }
        [Required]
        public Place PlaceNew { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
