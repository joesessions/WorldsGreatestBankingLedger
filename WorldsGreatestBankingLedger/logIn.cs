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
            user currentUser = null;
            bool logInSuccess = false;
            Console.Clear();
            

            while (!logInSuccess)
            {

                Console.WriteLine();
                Console.WriteLine("Enter your username:");
                Console.WriteLine();
                string userName = Console.ReadLine();
                if (userName == "exit")
                {
                    currentUser.userName = "failedLogin";
                    return currentUser;
                }

                Console.WriteLine();
                Console.WriteLine("Enter your password:");
                Console.WriteLine();
                string password = Console.ReadLine();
                Console.WriteLine();

                for (int i=0; i<userList.Count; i++)
                {
                    if (userList[i].userName == userName && userList[i].password == password)
                    {
                        currentUser = userList[i];
                        logInSuccess = true;
                    }

                }
                if (!logInSuccess)            
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry, that doesn't match our records.");
                        Console.WriteLine("Enter \"exit\" to return to the main menu.");
                    }

            }

            
            return currentUser;
        }






public List<user> register(List<user> userList)
        {
            try
            {
                string passwordVerify;
                user newUser = new user();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Enter your username: (must be at least 3 characters)");
                newUser.userName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter your password: (2 characters)");
                newUser.password = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Re-enter your password: (2 characters)");
                passwordVerify = Console.ReadLine();
                Console.WriteLine();
                if (newUser.password == passwordVerify && newUser.password.Length <3 && newUser.password.Length > 0 && newUser.userName.Length>2 ){
                    Console.WriteLine("Great, that all looks good.");
                    Console.WriteLine();
                    Console.WriteLine("Enter your first name:");
                    newUser.firstName = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter your last name:");
                    newUser.lastName = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter your email address:");
                    newUser.email = Console.ReadLine();
                    newUser.userId = userList.Count;
                    Console.WriteLine();
                    Console.WriteLine("Welcome, {0}!", newUser.firstName);
                    userList.Add(newUser);
                    return userList;

                    
                }
                else if (newUser.password.Length >2)
                {
                    Console.WriteLine("Sorry, your password is too long.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    return userList;
                }
                else if (newUser.password.Length == 0)
                {
                    Console.WriteLine("Sorry, you must have a password.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    return userList;
                }
                else if (newUser.userName.Length <= 2)
                {
                    Console.WriteLine("Sorry, you need a longer username.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    return userList;
                }
                else
                {
                    Console.WriteLine("Sorry, your passwords do not match.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    return userList;
                }

            }
            catch
            {
                Console.WriteLine("Sorry, there was an error. Please try again.");
                return userList;
            }

        }
    }
}

  