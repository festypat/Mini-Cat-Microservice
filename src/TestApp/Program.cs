using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var model = new Credit
            {
                AppId = "21",
                ServiceId = "D04D",
                SessionID = "000001042720210325585421140186"
            };

            string data = null;

            if(string.IsNullOrEmpty(data))
            {
                string resps = "Valid data";
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://sbdevzone.sterling.ng/CreditSwitchApi/api/CreditSwitch/GetDataPlans", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            Console.ReadLine();
        }

        public class Credit
        {
            public string ServiceId { get; set; }
            public string SessionID { get; set; }
            public string AppId { get; set; }
        }
    }
    }

