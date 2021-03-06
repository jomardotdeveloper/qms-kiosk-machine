using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskQMS.Kiosk
{
    static class Endpoints
    {
        //74.63.204.84
        public static string WebsocketURL = "ws://127.0.0.1:8090";
        public static string BaseUrl = "http://127.0.0.1:8000/api/";

        //REQUIRED PARAMETER (PRODUCT KEY) GET
        public static string BranchUrl = "branches/get_branch_data/";

        //REQUIRED PARAMETER (account_number, mobile_number, window_id, service_id, branch_id, profile_id) POST
        // OPTIONAL (amount)
        public static string TransactionUrl = "transactions/make";

        //REQUIRED PARAMETER(branch_id, service_id, is_priority) GET
        public static string WindowUrl = "windows/available/";

        //REQUIRED PARAMETER(account_number, branch_id) GET
        public static string AccountUrl = "account/account_exists/";

        //REQUIRED PARAMETER (BRANCH ID) GET
        public static string CutoffUrl = "cutoffs/get_cutoff_data/";

        // GET BRANCH ID
        public static string BranchIDUrl = "server/get_branch_id/";
    }
}
