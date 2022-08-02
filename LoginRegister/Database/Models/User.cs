using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationWithClie.Database.Models;

namespace AuthenticationWithClie.Database.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Report> Reportinbox { get; set; } = new List<Report>();
        public User(string firstName, string lastName, string email, string password, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;
        }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = UserRepository.IdCounter;
        }

        public virtual string GetInfo()
        {
            return $"Hello user, {FirstName} {LastName}";
        }
        public virtual string Info()
        {
            return $"User :  {FirstName} {LastName} {Email} ";
        }
    }
}
