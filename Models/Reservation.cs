namespace SD_115_W22SD_Labs.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime Created { get; set; } = new DateTime();
        public DateTime StartDate { get; set; } = new DateTime();

        public int Occupants { get; set; }

        public Reservation (int id, Client client, Room room, DateTime startDate, int occupants)
        {
            Id = id;
            Client = client;
            Room = room;
            IsCurrent = true;
            StartDate = startDate;
            Occupants = occupants;
        }
    }
}
