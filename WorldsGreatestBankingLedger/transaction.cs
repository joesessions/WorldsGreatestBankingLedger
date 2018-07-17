using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsGreatestBankingLedger
{
    public class transaction
    {
        public int transactID { get; set; }
        public DateTime date{ get; set; } = new DateTime();
        public float amount { get; set; }
        public string notes { get; set; }
    }
}
