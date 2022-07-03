namespace SD_115_W22SD_Labs.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomNum { get; set; }
        public int Capacity { get; set; }
        public bool Occupied { get; set; } = false;
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public Room(int iD, string roomNum, bool occupied, int capacity)
        {
            ID = iD;
            RoomNum = roomNum;
            Occupied = occupied;
            Capacity = capacity;
        }
    }
}
