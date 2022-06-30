namespace SD_115_W22SD_Labs.Models
{
    public class Client
    {
        public int ClientId { get; set; } = 0;
        public string Name { get; set; }
        public long CreditCard { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public Client(string name, long creditCard)
        {
            Name = name;
            CreditCard = creditCard;
            ClientId++;
        }
    }
}
