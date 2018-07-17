using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    public class logIn
    {
        public user login(List<user> userList)
        {
            // Initialize variables
            user currentUser = userList[0];
            bool logInSuccess = false;

            

            while (!logInSuccess)
            {
                Console.WriteLine("Enter your username:");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter your password: (a maximum of 2 characters!)");
                string password = Console.ReadLine();

                for (int i=0; i<userList.Count; i++)
                {
                    if (userList[i].userName == userName)
                    {
                        currentUser = userList[i];
                        logInSuccess = true;
                    }

                }
                if (!logInSuccess)            
                    {
                        Console.WriteLine("Sorry, that doesn't match our records. Try again, or restart the app to register.");
                    }

            }

            
            return currentUser;
        }






public void register()
        {
            string username, password;
            Console.WriteLine("Enter your username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter your password: (a maximum of 2 characters!)");
            password = Console.ReadLine();
            Console.WriteLine("Re-enter your password: (a maximum of 2 characters!)");
            password = Console.ReadLine();
        }
    }
}

  