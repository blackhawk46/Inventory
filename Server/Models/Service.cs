﻿using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Double Price { get; set; }
    }
}
