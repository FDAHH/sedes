using System;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models.Frontend
{
    public class ZSeat
    {
        [Key]
        public int Id { get; set; }
        public ZRoom Room { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public bool isAvailable { get; set; }
        private int myVar;

        public int MyProperty
        {
            get { return myVar = Random.Shared.Next(); }
            set { myVar = value; }
        }


    }
}