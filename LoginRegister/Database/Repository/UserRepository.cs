using AuthenticationWithClie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.Database.Repository
{
    class UserRepository
    {

        public static List<Report> Reports { get; set; } = new List<Report>();


        private static int _idCounter;

        public static int IdCounter
        {
            get 
            {
                _idCounter++;
                return _idCounter; 
            }
        }



        private static List<User> Users { get; set; } = new List<User>()
        {
            new Admin("Mahmood", "Garibov", "qaribovmahmud@gmail.com", "123321"),
            new User("Eshqin", "Mahmudov", "eshqin@gmail.com", "123321"),
            new User("Mikayil", "Mikayilli", "mikayil@gmail.com", "123321"),
            new Admin("Zeynal","Mikayilli", "zeynal@gmail.com", "123321")
        };



        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password, IdCounter);
            Users.Add(user);
            return user;
        }

        public static User AddUser(string firstName, string lastName, string email, string password, int id)
        {
            User user = new User(firstName, lastName, email, password, id);
            Users.Add(user);
            return user;
        }

        public static User AddUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public static User AddUser(Admin user)
        {
            Users.Add(user);
            return user;
        }

        public static List<User> GetAll()
        {
            return Users;
        }

        public static int GetUserCount()
        {
            return Users.Count;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("sistemde bele bir admin/istifadeci yoxdur.");
            return false; ;
        }

        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            Console.WriteLine("bele bir istifadeci yoxdur.");
            return null;
        }

        public static void Delete(User user)
        {
            Users.Remove(user);
        }

        public static void UpdateAdmin()
        {
            Console.WriteLine("adminin emailini yazin.");
            string emailUpdateAdmin = Console.ReadLine();
            User user1 = UserRepository.GetUserByEmail(emailUpdateAdmin);
            if (user1 is Admin)
            {
                Console.WriteLine("yeni adi qeyd edin.");
                string newFirstName = Console.ReadLine();
                Console.WriteLine("yeni soyadi qeyd edin.");
                string newLastName = Console.ReadLine();
                user1.FirstName = newFirstName;
                user1.LastName = newLastName;
                Console.WriteLine($"{user1.FirstName} {user1.LastName} changed to {newFirstName} {newLastName}");
            }
            else
            {
                Console.WriteLine("email tapilmadi");
            }

        }

        public static void ShowAdmins()
        {
            foreach (User user in Users)
            {
                if (user is Admin)
                {
                    Console.WriteLine(user.Info());
                }
            }

        }


        











        public static void AddReport(User sender, string reason, User target)
        {
            Report report = new Report(sender, reason, target);
            Reports.Add(report);
            target.Reportinbox.Add(report);   
        }

    }
}
