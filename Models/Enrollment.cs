namespace sedes.Models
{

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int RoomID { get; set; }
        public int SeatID { get; set; }
        

        public Room Room { get; set; }
        public Seat Seat { get; set; }
    }
}