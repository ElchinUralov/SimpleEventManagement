namespace imtihon1.Models
{
    public class Company : ICompany
    {
        public int Id_Company { get; set; }
        public string Name { get; set; }

        public Company(int id_Company, string name)
        {
            Id_Company = id_Company;
            Name = name;
        }
    }
}
