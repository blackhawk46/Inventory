using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset? Asset { get; set; }
        public DateTime DateBegin   { get; set; }   
        public DateTime? DateEnd { get; set; }
        public string Name { get; set; }
        public Detail? Detail { get; set; }
        public Service? Service { get; set; }
        public Double? TotalPrice { get; set; }
        public string? Description { get; set; }
    }
}
