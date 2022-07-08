namespace SD_115_W22SD_Labs.Models
{
    public static class Hotel
    {
        public static ICollection<Client> Clients { get; set; } = new HashSet<Client>();
        public static ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
        public static ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public static int IdCounter { get; set; } = 0;

        static Hotel()
        {
            Client clientOne = new Client("Jim Halpert", 21348237182);
            Client clientTwo = new Client("Dwight Schrute", 2124829328);
            Client clientThree = new Client("Michael Scott", 2182941723);

            Room roomOne = new Room(IdCounter++, "101", false, 4);
            Room roomTwo= new Room(IdCounter++, "102", false, 2);
            Room roomThree = new Room(IdCounter++, "103", false, 6);

            Clients.Add(clientOne);
            Clients.Add(clientTwo);
            Clients.Add(clientThree);
            Rooms.Add(roomOne);
            Rooms.Add(roomTwo);
            Rooms.Add(roomThree);

            Reservation reservationOne = new Reservation(IdCounter++, clientOne, roomOne);
            Reservations.Add(reservationOne);
            clientOne.Reservations.Add(reservationOne);
            roomOne.Reservations.Add(reservationOne);

            Reservation reservationTwo = new Reservation(IdCounter++, clientTwo, roomTwo);
            Reservations.Add(reservationTwo);
            clientTwo.Reservations.Add(reservationTwo);
            roomTwo.Reservations.Add(reservationTwo);
        }

        public static Client GetClient(int clientId)
        {
            Client currentClient = Clients.First(c => c.ClientId == clientId);
            return currentClient;
        }

        public static Reservation GetReservation(int ID)
        {
            Reservation currentReservation = Reservations.First(r => r.Id == ID);
            return currentReservation;
        }

        public static Room GetRoom(string roomNum)
        {
            Room currentRoom = Rooms.First(r => r.RoomNum == roomNum);
            return currentRoom;
        }

        public static List<Room> GetVacantRooms()
        {
            List<Room> vacantRoom = Rooms.Where(r => !r.Occupied).ToList();
            return vacantRoom;
        }

        public static List<Client> TopThreeClients()
        {
            List<Client> listOfClientByReservation = Clients.OrderByDescending(c => c.Reservations.Count).ToList();
            List<Client> topThreeClients = new List<Client>();
            for(int i = 0; i < 3; i++)
            {
                topThreeClients.Add(listOfClientByReservation.ElementAt(i));
            }
            return topThreeClients;
        }

        public static Reservation AutomaticReservation(int clientID, int occupants)
        {
            try
            {
                List<Room> vacantRoom = GetVacantRooms();
                Room suitableRoom = vacantRoom.First(v => v.Capacity >= occupants);
                Client myClient = GetClient(clientID);
                Reservation newReservation = new Reservation(IdCounter++, myClient, suitableRoom);
                suitableRoom.Reservations.Add(newReservation);
                myClient.Reservations.Add(newReservation);
                Reservations.Add(newReservation);
                return newReservation;
            } catch
            {
                throw new Exception("Invalid Booking");
            }
            
        }
    }
}
