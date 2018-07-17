using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a user for testing
            var BobSmithCheckingTransaction1 = new transaction
            {
                transactID = 1,
                date = DateTime.Now,
                amount = 3000,
                notes = "Initial cash deposit"
            };
            var BobSmithCheckingTransaction2 = new transaction
            {
                transactID = 1,
                date = DateTime.Now,
                amount = -2711,
                notes = "Trip to candy store. I think I have a problem."
            };
            var BobSmithChecking = new account
            {
                acctID = 1,
                name = "Main",
                acctType = 1,
                transactions = new List<transaction> { BobSmithCheckingTransaction1, BobSmithCheckingTransaction2 },
            };
            var BobSmithSavingsTransaction1 = new transaction
            {
                transactID = 1,
                date = DateTime.Now,
                amount = 1,
                notes = "Initial cash deposit"
            };
            var BobSmithSavings = new account
            {
                acctID = 2,
                name = "Main",
                acctType = 2,
                transactions = new List<transaction> { BobSmithSavingsTransaction1 },
            };
            user bobS = new user()
            {
                userName = "bobS",
                email = "bs@fake.com",
                firstName = "Bob",
                lastName = "Smith",
                password = "bs",
                accounts = new List<account> { BobSmithChecking, BobSmithSavings },
            };
            user samT = new user()
            {
                userName = "samT",
                email = "st@fake.com",
                firstName = "Sam",
                lastName = "Tom",
                password = "st",
                accounts = new List<account> { BobSmithChecking },
            };
            var userList = new List<user> { bobS, samT };


            // Instantiate login object
            logIn establishUser = new logIn();

            
            // Startup screen

            string logInOrRegister;
            Console.WriteLine("Welcome to the World's Greatest Banking App!");
            Console.WriteLine();
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1  --  Login");
            Console.WriteLine("2  --  Register (new user)");
            logInOrRegister = Console.ReadLine();

            if (logInOrRegister == "1")
            {
                
            }
            else if (logInOrRegister == "2")
            {
                establishUser.register();
            }
            else
            {
                Console.WriteLine("Okay. Goodbye!");
                Console.ReadKey();
            }
            user currentUser = establishUser.login(userList);
            Console.WriteLine("Welcome back, {0}", currentUser.firstName);

            // Home screen
            bool moreTransactions = true;

            while (moreTransactions)
            {
                homeScreen currentCycle = new homeScreen();
                currentUser = currentCycle.homescreen(currentUser);
                Console.WriteLine("Could I do something else for you?");
                string moreAnswer = Console.ReadLine();
                if (moreAnswer == "n" || moreAnswer == "no" || moreAnswer == "N" || moreAnswer == "NO" || moreAnswer == "No")
                {
                    moreTransactions = false;
                } 
            }





            Console.WriteLine("That's all folks!");
            Console.ReadLine();

        }
    }
}


//enum acctType : { Checking = 1, Savings, MoneyMarket }