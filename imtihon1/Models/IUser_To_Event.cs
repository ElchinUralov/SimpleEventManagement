namespace imtihon1.Models
{
    public interface IUser_To_Event
    {
        public int Id_User_Event { get; set; }
        public int Id_User { get; set; }
        public int Id_Event { get; set; }
    }
}
