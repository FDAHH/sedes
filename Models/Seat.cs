using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public Room Room { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public bool isAvailable { get; set; }

    }
}