namespace imtihon1.Models
{
    public interface IRoom
    {
        public int Id_Room { get; set; }
        public int Number_Of_Places { get; set; }
        public StatusOfRoom Status { get; set; }
    }
    public enum StatusOfRoom
    {
        empty,
        busy
    }
}
