
namespace ReservationApi.Models
{
    public class Repository : IRepository

    {
        public Dictionary<int, Reservation> items;

        public Repository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation>{
        new Reservation{Id = 1, Name="Ravindiran",StartLocation="Sankarapuram", EndLocation="Tirukoilur"},
        new Reservation{Id = 2, Name="Suresh",StartLocation="Sankarapuram", EndLocation="Chennai"},
        new Reservation{Id = 3, Name="Hamsa",StartLocation="Tirukoilur", EndLocation="Chennai"},
        new Reservation{Id = 4, Name="Dhanesh",StartLocation="Tirukoilur", EndLocation="Sankarapuram"},
    }.ForEach(r => AddReservation(r));
        }


        public Reservation this[int id] => items.ContainsKey(id)?items[id]:null;

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation AddReservation(Reservation reservation)
        {
           if(reservation.Id==0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reservation.Id = key;
            }
            items[reservation.Id]=reservation;
           return reservation;
        }

       
        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);

        public void DeleteReservation(int id) => items.Remove(id);
    }
}
