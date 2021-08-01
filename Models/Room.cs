using System;
using System.Collections.Generic;

namespace sedes.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int BuildingID { get; set; }
        public string Name { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }

}