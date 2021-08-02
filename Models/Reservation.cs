using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Reservation
    {
       [Key]
       public int Id { get; set; }
       [Required]
       public Person Person { get; set; }
       [Required]
       public Seat Seat { get; set; }
       [Required]
       public DateTime Start { get; set; }
       [Required]
       public DateTime End  { get; set; }
    }

}