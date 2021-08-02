using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }

}