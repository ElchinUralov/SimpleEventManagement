namespace imtihon1.Models
{
    public interface IUser
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public Role_User Role { get; set; }
    }

    public enum Role_User
    {
        Admin,
        User
    }
}
