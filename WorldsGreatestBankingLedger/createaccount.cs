using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    public class createAccount
    {
        public user newAccount(user currentUser)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Which type of account would you like to open?");
            Console.WriteLine();
            Console.WriteLine("1 - Checking");
            Console.WriteLine("2 - Savings");
            Console.WriteLine("3 - Exit to Main Menu");
            bool menuSuccess = false;
            account newAcct = new account();
            while (!menuSuccess)
            {

                try
                {
                    newAcct.acctID = currentUser.accounts.Count+1;
                    newAcct.acctType = Convert.ToInt32(Console.ReadLine());
                    if (newAcct.acctType == 1 || newAcct.acctType == 2)
                    {
                        Console.WriteLine();
                        bool acctNamed = false;
                        while (!acctNamed)
                        {
                            Console.WriteLine("What would you like to name this account?");
                            Console.WriteLine();
                            newAcct.name = Console.ReadLine();
                            if (newAcct.name != "")
                            {
                                acctNamed = true;
                            }
                            else
                            {
                                Console.WriteLine("You must give the account a name.");
                                Console.WriteLine();
                            }
                        }

                        currentUser.accounts.Add(newAcct);
                        menuSuccess = true;
                        
                        Console.WriteLine("Great! That account is now open.");
 
                    }
                    if (newAcct.acctType == 3)
                    {
                        return currentUser;
                    }
                     
                }
                catch
                {
                    Console.WriteLine("Sorry, try again.");
                    Console.Clear();
                    return currentUser;
                }
            }

            return currentUser;

        } 
    }
}
