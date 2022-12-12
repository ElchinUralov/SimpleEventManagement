namespace imtihon1.Models
{
    public interface IEvent
    {
        public int Id_Event { get; set; }
        public int Id_Company_To_Order { get; set; }
        public int Id_Room { get; set; }
        public StatusOfEvent Status { get; set; }
    }
    public enum StatusOfEvent
    {
        Not_Active,
        Active
    }
}
