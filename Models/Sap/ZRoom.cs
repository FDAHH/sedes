using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models.Sap
{
    public class ZRoom
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public int Floor { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; }
        public Building Building { get; set; }
        public Seat[] Seats { get; set; }
    }

}