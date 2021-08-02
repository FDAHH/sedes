using System;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Seat
    {
        [Key]
        public int Id {get; set;}
        
        [MaxLength(100)]
        public string name{get; set;}
        public bool isAvailable { get; set; }
    }
}