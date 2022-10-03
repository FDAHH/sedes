using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models
{
    public class Reservation
    {
       [Key]
       public int Id { get; set; }
       public int RoomId { get; }
       public int BuildingId { get; }
       public int SeatId { get; }
       
       [Required]
       public Person Person { get; set; }
       [Required]
       public Seat Seat { get; set; }
       [Required]
       public Building Building { get; set; }
       [Required]
       public DateTime Start { get; set; }
       [Required]
       public DateTime End  { get; set; }
       
       
       public TimeSpan Duration { 
            get { return End - Start; }
            }
    }

}