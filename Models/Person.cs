using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string ExtRef { get; set; }

    }
}