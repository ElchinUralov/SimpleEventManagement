namespace imtihon1.Models
{
    public class Event : IEvent
    {
        public int Id_Event { get; set; }
        public int Id_Company_To_Order { get; set; }
        public int Id_Room { get; set; }
        public StatusOfEvent Status { get; set; }

        public Event(int id_Event, int id_Company_To_Order, int id_Room, StatusOfEvent status)
        {
            Id_Event = id_Event;
            Id_Company_To_Order = id_Company_To_Order;
            Id_Room = id_Room;
            Status = status;
        }
    }
}
