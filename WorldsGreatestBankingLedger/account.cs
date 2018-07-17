using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    public class account
    {
        public int acctID { get; set; }
        public string name { get; set; }
        public int acctType { get; set; } 
        public List<transaction> transactions { get; set; } = new List<transaction>();


    }
}
