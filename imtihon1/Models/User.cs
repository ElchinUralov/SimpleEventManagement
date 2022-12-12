namespace imtihon1.Models
{
    public class User : IUser
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public Role_User Role { get; set; }

        public User(int id_User, string name, Role_User role)
        {
            Id_User = id_User;
            Name = name;
            Role = role;
        }
    }
}
