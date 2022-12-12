namespace imtihon1.Models
{
    public class User_To_Event : IUser_To_Event
    {
        public int Id_User_Event { get; set; }
        public int Id_User { get; set; }
        public int Id_Event { get; set; }

        public User_To_Event(int id_User_Event, int id_User, int id_Event)
        {
            Id_User_Event = id_User_Event;
            Id_User = id_User;
            Id_Event = id_Event;
        }
    }
}
