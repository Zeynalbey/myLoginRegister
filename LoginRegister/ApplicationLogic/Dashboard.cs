using AuthenticationWithClie.Database.Models;
using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationWithClie.ApplicationLogic.Validations;

namespace AuthenticationWithClie.ApplicationLogic
{
    public static partial class Dashboard
    {
        
        public static void AdminPanel()
        {
            
            while (true)
            {
                Console.WriteLine($"/add-user");
                Console.WriteLine("/update-user");
                Console.WriteLine("/remove-user");
                Console.WriteLine("/reports");
                Console.WriteLine("/add-admin");
                Console.WriteLine("/change-admin-to-user");
                Console.WriteLine("/show-admins");
                Console.WriteLine("/update-admin");
                Console.WriteLine("/remove-admin");
                Console.WriteLine("exit");

                string command = Console.ReadLine();

                if (command == "/add-user")
                {
                    Authentication.Register();
                }
                else if (command == "/update-user")
                {
                    Console.WriteLine("deyismek istediyiniz emaili daxil edin.");
                    string email = Console.ReadLine();
                    User user1 = UserRepository.GetUserByEmail(email);
                    if (!(user1 == null && user1 is Admin))
                    {
                        Console.Write("adi daxil edin:");
                        string user1Name = Console.ReadLine();
                        Console.Write("Soyadi daxil edin:");
                        string user1LastName = Console.ReadLine();
                        user1.FirstName = user1Name;
                        user1.LastName = user1LastName;
                        Console.WriteLine($"{user1.FirstName} {user1.LastName} changed to {user1Name} {user1LastName}");
                    }
                    else
                    {
                        Console.WriteLine("bu email-i deyismek olmaz.");
                    }
                }
                else if (command == "/remove-user")
                {
                    Console.WriteLine("silmek istediyiniz userin emailini daxil edin.");
                    string removeEmail = Console.ReadLine();
                    User user1 = UserRepository.GetUserByEmail(removeEmail);
                    if (!(user1 is null && user1 is Admin))
                    {
                        UserRepository.Delete(user1);
                        Console.WriteLine($"user1.GetInfo() silindi");
                    }
                    else
                    {
                        Console.WriteLine("bele bir istifadeci yoxdur ve ya admindir.");
                    }

                }
                else if (command == "/reports")
                {
                    for (int i = 0; i < Authentication.Account.Reportinbox.Count; i++)
                    {
                        Report report = Authentication.Account.Reportinbox[i];
                        Console.WriteLine($"{i + 1}. (report ID : {report.Id}) User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
                    }
                }
                else if (command == "/all-reports")
                {
                    for (int i = 0; i < UserRepository.Reports.Count; i++)
                    {
                        Report report = UserRepository.Reports[i];
                        Console.WriteLine($"{i + 1}. (report ID : {report.Id}) User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
                    }
                }
                else if (command == "/add-admin")
                {
                    Console.WriteLine("admin etmek istediyiniz emaili daxil edin.");
                    string email = Console.ReadLine();
                    User user = UserRepository.GetUserByEmail(email);
                    if (!(user is null && user is Admin))
                    {
                        UserRepository.Delete(user);
                        Admin admin = new Admin(user.FirstName, user.LastName, user.Email, user.Password, user.Id);
                        UserRepository.AddUser(admin);
                    }
                    else
                    {
                        Console.WriteLine("duzgun email daxil edin.");
                    }

                }
                else if (command == "/change-admin-to-user")
                {
                    Console.WriteLine("emaili daxil edin.");
                    string email = Console.ReadLine();
                    User user = UserRepository.GetUserByEmail(email);
                    if (!(user is null) && user is Admin)
                    {
                        UserRepository.Delete(user);
                        User user1 = new User(user.FirstName, user.LastName, user.Email, user.Password, user.Id);
                        UserRepository.AddUser(user1);
                        Console.WriteLine($"{user1.FirstName} {user1.LastName} user now.");

                    }
                    else
                    {
                        Console.WriteLine( "emaili duzgun daxil edin.");
                    }
                }
                else if (command == "/show-admins")
                {
                    UserRepository.ShowAdmins();
                }
                else if (command == "/update-admin")
                {
                    UserRepository.UpdateAdmin();
                }
                else if (command == "/remove-admin")
                {
                    Console.WriteLine("silmek istediyiniz adminin emailini yazin.");
                    string emailDeleteAdmin = Console.ReadLine();
                    User user = UserRepository.GetUserByEmail(emailDeleteAdmin);
                    if (user is Admin)
                    {
                        UserRepository.Delete(user);
                        Console.WriteLine($"{user.FirstName} {user.LastName} silindi.");
                    }
                }
                else if (command == "/exit")
                {
                    break;
                }
              
            }
            
        }
    }
    public static partial class Dashboard
    {
        public static void UserPanel()
        {
            Console.WriteLine("/update-info" +" " + "/report-user");
            string command = Console.ReadLine();

            if (command == "/update-info")
            {
                //string updateEmail = Console.ReadLine();
                //User user1 = UserRepository.GetUserByEmail(updateEmail);
                Console.Write("Please enter your password : ");
                string password = Console.ReadLine();
                if (Authentication.Account.Password == password)
                {
                    Console.WriteLine("yeni adi yazin.");
                    string newName = Console.ReadLine();
                    Console.WriteLine("yeni soyadi yazin.");
                    string newLastName = Console.ReadLine();
                    Authentication.Account.FirstName = newName;
                    Authentication.Account.LastName = newLastName;
                }
                else
                {
                    Console.WriteLine("emaili duzgun daxil edin.");
                }
            }
            else if (command == "/report-user")
            {
                Console.Write("Please enter target's email : ");
                string email = Console.ReadLine();
                Console.Write("Please enter reason of report : ");
                string reason = Console.ReadLine();
                if (email != Authentication.Account.Email && Validation.IsLengthBetween(reason, 10, 50) && UserRepository.IsUserExistsByEmail(email))
                {
                    User target = UserRepository.GetUserByEmail(email);
                    UserRepository.AddReport(Authentication.Account, reason, target);
                    Console.WriteLine("User Reported");
                }
                else
                {
                    Console.WriteLine("Rules : \n1. A User cannot report their own account \n2. The email entered must be valid \n3. The reason's length entered must be higher than 10 and less than 30 ");
                }
            }
            else if (command == "/reports")
            {
                for (int i = 0; i < Authentication.Account.Reportinbox.Count; i++)
                {
                    Report report = Authentication.Account.Reportinbox[i];
                    Console.WriteLine($"{i + 1}. (report ID : {report.Id}) User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
                }
            }
            else
            {
                Console.WriteLine("Command not found");
            }

        }
    }
}