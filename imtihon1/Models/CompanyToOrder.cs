namespace imtihon1.Models
{
    public class CompanyToOrder : ICompanyToOrder
    {
        public int Id_Company_Order { get; set; }
        public int Id_Company { get; set; }
        public int Id_Order { get; set; }
        public StatusOfOrder Status { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Number_Of_Spaces { get; set; }

        public CompanyToOrder(int id_Company_Order, int id_Company, int id_Order, StatusOfOrder status, DateTime start_Time, DateTime end_Time, int number_Of_Spaces)
        {
            Id_Company_Order = id_Company_Order;
            Id_Company = id_Company;
            Id_Order = id_Order;
            Status = status;
            Start_Time = start_Time;
            End_Time = end_Time;
            Number_Of_Spaces = number_Of_Spaces;
        }
    }
}
