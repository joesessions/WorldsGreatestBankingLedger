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
            // Instantiate users 
            var BobSmithCheckingTransaction1 = new transaction
            {
                transactID = 1,
                date = new DateTime(2018, 7, 15),
                amount = 3000,
                notes = "Initial cash deposit"
            };
            var BobSmithCheckingTransaction2 = new transaction
            {
                transactID = 1,
                date = new DateTime(2018, 7, 16),
                amount = -2711,
                notes = "Bought candy at candy store"
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
                date = new DateTime(2018, 7, 14),
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
                userId = 0,
                email = "bs@fake.com",
                firstName = "Bob",
                lastName = "Smith",
                password = "bs",
                accounts = new List<account> { BobSmithChecking, BobSmithSavings },
            };
            var SamTomCheckingTransaction1 = new transaction
            {
                transactID = 1,
                date = new DateTime(2018, 7, 14),
                amount = 4000,
                notes = "Initial cash deposit"
            };
            var SamTomChecking = new account
            {
                acctID = 1,
                name = "Normal",
                acctType = 1,
                transactions = new List<transaction> { SamTomCheckingTransaction1 },
            };
            user samT = new user()
            {
                userName = "samT",
                userId = 1,
                email = "st@fake.com",
                firstName = "Sam",
                lastName = "Tom",
                password = "st",
                accounts = new List<account> { SamTomChecking },
            };
            var userList = new List<user> { bobS, samT };


            // Instantiate login object
            logIn establishUser = new logIn();

            
            // Startup screen

            string logInOrRegister;

            Console.WriteLine();

            bool programRunning = true;
            while (programRunning)
            {
                // Start of login procedure 
                user currentUser = null;
                bool loginSuccess = false;
                while (!loginSuccess)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Welcome to the World's Greatest Banking Ledger!");
                    Console.WriteLine();
                    Console.WriteLine("Please choose one of the following:");
                    Console.WriteLine("1  --  Login");
                    Console.WriteLine("2  --  Register (new user)");
                    Console.WriteLine("3  --  Exit");
                    Console.WriteLine();
                    logInOrRegister = Console.ReadLine();
                    Console.WriteLine();
                    try
                    {
                        if (logInOrRegister == "1")
                        {
                            while (currentUser == null)
                            {
                                currentUser = establishUser.login(userList);
                            }
                            if (currentUser.userName != "failedLogin")
                            {
                                Console.WriteLine("Welcome back, {0}", currentUser.firstName);
                                loginSuccess = true;
                            }

                        }
                        else if (logInOrRegister == "2")
                        {
                            int userCount = userList.Count;
                            userList = establishUser.register(userList);
                            if (userCount + 1 == userList.Count)
                            {
                                int newestUser = userList.Count-1;
                                currentUser = userList[newestUser];
                                loginSuccess = true;
                            }

                        }
                        else if (logInOrRegister == "3")
                        {
                            Console.WriteLine("Okay. Goodbye!");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch
                    {

                    }

                }



                // User logged in, going to home screen
                currentUser.loggedIn = true;
                while (currentUser.loggedIn)
                {
                    homeScreen currentCycle = new homeScreen();

                    // for new users with no accounts
                    if (currentUser.accounts.Count == 0)
                    {
                        createAccount acctCreator = new createAccount();
                        // method will update user with a newly created account in the user object.
                        currentUser = acctCreator.newAccount(currentUser);
                    }

                    currentUser = currentCycle.homescreen(currentUser);
                    //updates list item
                    userList[currentUser.userId] = currentUser;
                    Console.Clear();
                    Console.WriteLine();
                    //Console.WriteLine("Could I do something else for you? (\"n\" to logout)");
                    //Console.WriteLine();
                    //string moreAnswer = Console.ReadLine();
                    //Console.WriteLine();
                    //if (moreAnswer == "n" || moreAnswer == "no" || moreAnswer == "N" || moreAnswer == "NO" || moreAnswer == "No")
                    //{
                    //    Console.WriteLine("Okay! Thanks for using the World's Greatest Banking Ledger!");
                    //    Console.WriteLine();
                    //    Console.ReadLine();
                    //    Console.Clear();
                    //    moreTransactions = false;
                    }
                }
            


            


            Console.WriteLine("That's all folks!");
            Console.ReadLine();

        }
    }
}

