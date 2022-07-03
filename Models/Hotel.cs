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
            Room roomFour = new Room(IdCounter++, "104", false, 2);

            Clients.Add(clientOne);
            Clients.Add(clientTwo);
            Clients.Add(clientThree);
            Rooms.Add(roomOne);
            Rooms.Add(roomTwo);
            Rooms.Add(roomThree);
            Rooms.Add(roomFour);

            Reservation newReservationOne = new Reservation(IdCounter++, clientOne, roomOne, new DateTime(), 2);
            Reservations.Add(newReservationOne);
            clientOne.Reservations.Add(newReservationOne);
            roomOne.Reservations.Add(newReservationOne);
            Checkin(clientOne.Name);

            AutomaticReservation(1, 2);
            Client myClient = GetClient(1);
            Checkin(myClient.Name);
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
                Reservation newReservation = new Reservation(IdCounter++, myClient, suitableRoom, new DateTime(2022, 07, 21), occupants);
                suitableRoom.Reservations.Add(newReservation);
                myClient.Reservations.Add(newReservation);
                Reservations.Add(newReservation);
                return newReservation;
            } catch
            {
                throw new Exception("Invalid Booking");
            }
        }

        public static void Checkin(string clientName)
        {
            Reservation updateReservation = Reservations.First(r => r.Client.Name.Equals(clientName));
            updateReservation.Room.Occupied = true; 
            updateReservation.IsCurrent = true;
        }

        public static void Checkout(int roomNum)
        {
            Reservation updateReservation = Reservations.First(r => r.Room.RoomNum.Equals(roomNum));
            updateReservation.Room.Occupied = false;
            updateReservation.IsCurrent = false;
        }

        public static void Checkout(string clientName)
        {
            Reservation updateReservation = Reservations.First(r => r.Client.Name.Equals(clientName));
            updateReservation.Room.Occupied = false;
            updateReservation.IsCurrent = false;
        }

        public static int TotalCapacityRemaining()
        {
            int totalCapacity = Rooms.Sum(r => r.Capacity);
            int occupants = Reservations.Sum(r => r.Occupants);
            int capacityRemaining = totalCapacity - occupants;
            return capacityRemaining;
        }

        public static int AverageOccupancyPercentage()
        {
            List<Reservation> currentReservation = Reservations.Where(r => r.IsCurrent.Equals(true)).ToList();
            int totalOccupants = currentReservation.Sum(r => r.Occupants);
            int totalCapacity = currentReservation.Sum(r => r.Room.Capacity);
            int average = (totalOccupants / totalCapacity) * 100;
            return average;
        }

        public static List<Reservation> FutureBooking()
        {
            DateTime todaysDate = new DateTime();
            List<Reservation> futureBooking = Reservations.Where(r => r.StartDate > todaysDate).ToList();
            return futureBooking;
        }
    }
}
