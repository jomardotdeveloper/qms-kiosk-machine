using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KioskQMS.Kiosk
{
    public static class TCreator
    {
        public static Transaction CreateTransaction(Transaction transaction)
        {
            /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
            HttpClientHandler Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            HttpClient Client = new HttpClient(Handler);
            Client.BaseAddress = new Uri(Endpoints.BaseUrl);

            IDictionary<string, string> data = new Dictionary<string, string>();
            
            data.Add("branch_id", transaction.BranchID.ToString());
            data.Add("service_id", transaction.ServiceID.ToString());

            if(transaction.AccountNumber != null)
            {
                data.Add("account_number", transaction.AccountNumber);
            }

            if(transaction.MobileNumber != null)
            {
                data.Add("mobile_number", transaction.MobileNumber);
                data.Add("is_notifiable", "1");
            }

            if (transaction.Amount != null)
            {
                data.Add("amount", transaction.Amount);
            }

            if(transaction.Loan != null)
            {
                data.Add("loan_id", transaction.Loan);
            }

            if(transaction.Bill != null)
            {
                data.Add("bill_id", transaction.Bill);
            }

            var response = Client.PostAsJsonAsync(Endpoints.TransactionUrl, data).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            
            DateTime oDate = Convert.ToDateTime(json["created_at"].ToString());

            DateTime myDate = TimeZoneInfo.ConvertTimeFromUtc(oDate, TimeZoneInfo.Local);

            transaction.MD = myDate;
            transaction.Token = json["token"].ToString();
            transaction.ID = Convert.ToInt32(json["id"]);
            transaction.Date = myDate.ToString();

            return transaction;

        }
    }
}
