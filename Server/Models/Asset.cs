using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string SerialNumber { get; set; } 
        [Required]
        public string InventoryNumber { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Place Place { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public AssetType AssetType { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } 
    }
}
