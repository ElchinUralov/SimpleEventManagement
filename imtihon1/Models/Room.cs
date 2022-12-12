namespace imtihon1.Models
{
    public class Room : IRoom
    {
        public int Id_Room { get; set; }
        public int Number_Of_Places { get; set; }
        public StatusOfRoom Status { get; set; }

        public Room(int id_Room, int number_Of_Places, StatusOfRoom status)
        {
            Id_Room = id_Room;
            Number_Of_Places = number_Of_Places;
            Status = status;
        }
    }
}
