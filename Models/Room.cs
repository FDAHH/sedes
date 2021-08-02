using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public int Floor { get; set; }
        public int BuildingID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }

}