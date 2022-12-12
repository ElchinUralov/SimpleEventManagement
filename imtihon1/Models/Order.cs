namespace imtihon1.Models
{
    public class Order : IOrder
    {
        public int Id_Order { get; set; }
        public string Topic { get; set; }
        public int Room { get; set; }

        public Order(int id_Order, string topic, int room)
        {
            Id_Order = id_Order;
            Topic = topic;
            Room = room;
        }
    }
}
