namespace SD_115_W22SD_Labs.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public long CreditCard { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public Client(int id, string name, long creditCard)
        {
            Name = name;
            CreditCard = creditCard;
            ClientId = id;
        }
    }
}
