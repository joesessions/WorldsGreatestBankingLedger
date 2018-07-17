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
            List<string> acctTypes = new List<string> { "Checking", "Savings", "Money Market" };
            int acctSelection = 1;

            Console.WriteLine();

            if (User.accounts.Count > 1)
            {
                Console.WriteLine("Which account would you like to work with?");
                Console.WriteLine();
                foreach (account acct in User.accounts)
                {
                    Console.WriteLine(acct.acctID + " " + acct.name + " " + acctTypes[acct.acctType-1]);
                }
                acctSelection = Convert.ToInt16(Console.ReadLine());


            }
            Console.WriteLine("What can I do for you today?");
            Console.WriteLine("1 -- Record deposits");
            Console.WriteLine("2 -- Record withdrawal");
            Console.WriteLine("3 -- Check balance");
            Console.WriteLine("4 -- See transaction History");
            Console.WriteLine("5 -- Log out");
            string userSelection = Console.ReadLine();

            if (userSelection == "1")
            {

                Console.WriteLine("How much did you deposit?");
                float transAmount = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Great! Would you like to make a note on this transaction? (optional)");
                string transactNote = Console.ReadLine();
                int nextTransactID = User.accounts[acctSelection-1].transactions.Count + 1 ;
                User.accounts[acctSelection-1].transactions.Add(new transaction { transactID = nextTransactID,
                                                                                date = DateTime.Now,
                                                                                amount = transAmount,
                                                                                notes = transactNote });
            };
            if (userSelection == "2")
            {
                Console.WriteLine("How much did you withdraw?");
                float transAmount = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Great! Would you like to make a note on this transaction? (optional)");
                string transactNote = Console.ReadLine();
                int nextTransactID = User.accounts[acctSelection - 1].transactions.Count + 1;
                User.accounts[acctSelection - 1].transactions.Add(new transaction
                {
                    transactID = nextTransactID,
                    date = DateTime.Now,
                    amount = -transAmount,
                    notes = transactNote
                });
            };
            if (userSelection == "3")
            {
                float balance = 0;
                for (int i = 0; i< User.accounts[acctSelection - 1].transactions.Count; i++)
                {
                    balance += User.accounts[acctSelection - 1].transactions[i].amount;
                }
               
                Console.WriteLine("Here is the balance for "+ acctSelection + " " + User.accounts[acctSelection-1].name + " " + acctTypes[User.accounts[acctSelection - 1].acctType - 1] + " = " + balance );
                
            };


            return User;
        }
    }

}
