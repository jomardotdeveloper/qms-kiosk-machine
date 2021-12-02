using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskQMS.Kiosk
{
    public class Transaction
    {
        public int ID { set; get; }

        // MERON NA TO
        public string AccountNumber { set; get; }
        
        // MERON NA TO
        public string MobileNumber { set; get; }

        // MERON NA TO
        public int WindowID { set; get; }

        // MERON NA TO
        public int ServiceID { set; get; }

        // MERON NA TO
        public int BranchID { set; get; }

        // MERON NA TO
        public int ProfileID { set; get; }

        // MERON NA TO
        public string Amount { set; get; }

        public string Date { set; get; }
        public string Token { set; get; }

        // MERON NA TO
        public bool IsPriority { set; get; }

        public DateTime MD { set; get; }

    }
}
