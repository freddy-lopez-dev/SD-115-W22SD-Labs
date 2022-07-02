namespace SD_115_W22SD_Labs.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime DateTime { get; set; } = new DateTime();

        public Reservation (int id, Client client, Room room)
        {
            Id = id;
            Client = client;
            Room = room;
        }
    }
}
