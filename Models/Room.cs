using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public int Floor { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public Building Building { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }

}