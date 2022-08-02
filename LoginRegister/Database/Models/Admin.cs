using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.Database.Models
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string email, string password, int id)
            :base(firstName, lastName, email, password, id)
        {
           

        }

        public Admin(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {


        }

        public override string GetInfo()
        {
            return $"Hello admin, {FirstName} {LastName} {Email}";
        }
        public override string Info()
        {
            return $" Admin : {FirstName} {LastName} {Email} ";
        }
    }
}
