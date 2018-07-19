using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    public class homeScreen
    {
        public user homescreen(user User)
        {
            // Initiatize variables
            List<string> acctTypes = new List<string> { "Checking", "Savings" };
            int acctSelection = 1;
            Console.WriteLine();

            bool accountSelected = false;
            while (!accountSelected && User.loggedIn)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Which account would you like to work with?");
                Console.WriteLine();
                Console.WriteLine("X Logout");
                Console.WriteLine("0 Add a new account");
                foreach (account acct in User.accounts)
                {
                    Console.WriteLine(acct.acctID + " " + acct.name + " " + acctTypes[acct.acctType - 1]);
                }
                try
                {
                    Console.WriteLine();
                    string acctSelectionString = Console.ReadLine();
                    if (acctSelectionString == "X" || acctSelectionString == "x")
                    {
                        User.loggedIn = false;
                    }
                    else
                    {
                        acctSelection = Convert.ToInt16(acctSelectionString);
                        Console.WriteLine();
                        if (acctSelection == 0)
                        {
                            createAccount acctCreator = new createAccount();
                            // method will update user with a newly created account in the user object.
                            User = acctCreator.newAccount(User);
                            acctSelection = User.accounts.Count;
                        }
                        else if (acctSelection > 0 && acctSelection <= User.accounts.Count)
                        {
                            accountSelected = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry, try again.");
                            Console.WriteLine();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, try again.");
                    Console.WriteLine();

                }
            }
            
            
            // Account is selected. Loop until user done with this account.
            bool moreWithThisAcct = true;
            while (moreWithThisAcct && User.loggedIn)
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("What shall we do with {0} {1}?", User.accounts[acctSelection-1].name, acctTypes[User.accounts[acctSelection-1].acctType-1] );
                Console.WriteLine();
                Console.WriteLine("1 -- Record deposit");
                Console.WriteLine("2 -- Record withdrawal");
                Console.WriteLine("3 -- Check balance");
                Console.WriteLine("4 -- See transaction history");
                Console.WriteLine("5 -- Done with this account");
                Console.WriteLine();
                string userSelection = Console.ReadLine();
                Console.WriteLine();

                if (userSelection == "1")
                {

                    Console.WriteLine("How much did you deposit?");
                    float transAmount = 0;
                    try
                    {
                        transAmount = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Enter a note for this transaction. (optional)");
                        string transactNote = Console.ReadLine();
                        int nextTransactID = User.accounts[acctSelection - 1].transactions.Count + 1;
                        User.accounts[acctSelection - 1].transactions.Add(new transaction
                        {
                            transactID = nextTransactID,
                            date = DateTime.Now,
                            amount = transAmount,
                            notes = transactNote
                        });
                        Console.WriteLine();

                    }
                    catch
                    {
                        Console.WriteLine("Sorry, your input was of the wrong format.");
                        Console.ReadLine();
                    }
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                        if (userSelection == "2")
                        {
                            Console.WriteLine("How much did you withdraw?");
                            float transAmount = Convert.ToSingle(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("Enter a note for this transaction. (optional)");
                            string transactNote = Console.ReadLine();
                            int nextTransactID = User.accounts[acctSelection - 1].transactions.Count + 1;
                            User.accounts[acctSelection - 1].transactions.Add(new transaction
                            {
                                transactID = nextTransactID,
                                date = DateTime.Now,
                                amount = -transAmount,
                                notes = transactNote
                            });
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                        }
                        if (userSelection == "3")
                        {
                            float balance = 0;
                            for (int i = 0; i < User.accounts[acctSelection - 1].transactions.Count; i++)
                            {
                                balance += User.accounts[acctSelection - 1].transactions[i].amount;
                            }
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Balance for account #" + acctSelection + " " + User.accounts[acctSelection - 1].name + " " + acctTypes[User.accounts[acctSelection - 1].acctType - 1] + ": " + balance);
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                        }   
                        if (userSelection == "4")
                        {
                            float balance = 0;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Transaction history for " + User.accounts[acctSelection - 1].name + " " + acctTypes[User.accounts[acctSelection - 1].acctType - 1] + ";");
                            Console.WriteLine();
                            Console.WriteLine("Date      Deposit      Withdrawal        Balance ");
                            Console.WriteLine();
                            for (int i = 0; i < User.accounts[acctSelection - 1].transactions.Count; i++)
                            {
                                balance += User.accounts[acctSelection - 1].transactions[i].amount;
                                string d;
                                if (User.accounts[acctSelection - 1].transactions[i].amount < 0)
                                {
                                    d = Convert.ToDateTime(User.accounts[acctSelection - 1].transactions[i].date).Date.ToString("d");
                                    Console.WriteLine(d + "                   (" + -User.accounts[acctSelection - 1].transactions[i].amount + ")           " + balance + "  " + User.accounts[acctSelection - 1].transactions[i].notes);
                                }
                                else
                                {
                                    d = Convert.ToDateTime(User.accounts[acctSelection - 1].transactions[i].date).Date.ToString("d");
                                    Console.WriteLine(d + "    " + User.accounts[acctSelection - 1].transactions[i].amount + "                    " + "        " + balance + "  " + User.accounts[acctSelection - 1].transactions[i].notes);
                                }
                                Console.WriteLine();

                            }
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                        }
                        if (userSelection == "5")
                        {
                            moreWithThisAcct = false;
                        }
                    }                  // end of loop to work with account
                    return User;
            }
        }
    }


