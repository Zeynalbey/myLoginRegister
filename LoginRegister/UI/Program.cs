using AuthenticationWithClie.ApplicationLogic;
using System;

namespace AuthenticationWithClie.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Commands :");
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/logout");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }
                else if (command == "/login")
                {
                    Authentication.Login();
                }
                else if (command == "/exit")
                {
                    break;
                }
                else if (command == "/login")
                {
                    Authentication.Logout();
                }
                else
                {
                    Console.WriteLine("Command not found!");
                }


            }



            //Order<string> test1 = new Order<string>();
            //test1.PrintUnderlineType();
            //All<string> all = new All<string>();
            //all.Metod();


            //Order<decimal> test = new All<decimal>();
            //test.PrintUnderlineType();
            //All<int> test2 = new All<int>();
            //test2.Metod();
            //test2.PrintUnderlineType();

        }

        //class Order<Type>
        //    where Type : class
        //{
        //    public void PrintUnderlineType()
        //    {
        //        Console.WriteLine(typeof(Type));
        //    }
        //}

        //class All<T>: Order<T>
        //    where T : class

        //{
        //    public void Metod()
        //    {
        //        Console.WriteLine(typeof(T));
        //    }
        //}




    }
}
