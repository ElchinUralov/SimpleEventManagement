namespace imtihon1.Models
{
    public interface IOrder
    {
        public int Id_Order { get; set; }
        public string Topic { get; set; }
        public int Room { get; set; }
    }
}
