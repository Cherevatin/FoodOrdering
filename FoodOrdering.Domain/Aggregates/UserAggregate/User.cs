using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.UserAggregate
{
    public enum Roles { Manager = 0, Cook = 1 , Employee = 2  };

    public class User : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public byte[] PasswordHash { get; private set; }

        public byte[] PasswordSalt { get; private set; }

        public Roles Role { get; private set; }

        public User(string name, 
            string surname, 
            string email, 
            byte[] passwordHash, 
            byte[] passwordSalt)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = Roles.Employee;
        }

        public User AppointAsCook()
        {
            Role = Roles.Cook;
            return this;
        }

        public User AppointAsEmployee()
        {
            Role = Roles.Employee;
            return this;
        }

        public User AppointAsManager()
        {
            Role = Roles.Manager;
            return this;
        }
    }
}
