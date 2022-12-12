namespace imtihon1.Models
{
    public interface ICompanyToOrder
    {
        public int Id_Company_Order { get; set; }
        public int Id_Company { get; set; }
        public int Id_Order { get; set; }
        public StatusOfOrder Status { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Number_Of_Spaces { get; set; }
    }
    public enum StatusOfOrder
    {
        Not_Confirmed,
        Confirmed
    }
}
