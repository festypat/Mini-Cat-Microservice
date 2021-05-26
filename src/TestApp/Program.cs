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


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://sbdevzone.sterling.ng/CreditSwitchApi");

               

            //    var postTask = await client.PostAsync<Credit>("student", model);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {

            //    }

            //        //HTTP GET
                 

            //    var request = JsonConvert.SerializeObject(model);

            //    var responseTask = await client.PostAsync("/api/CreditSwitch/GetDataPlans", 
            //        new StringContent(request, Encoding.UTF8, "application/json"));
            //   // responseTask.Wait();

            //   // var result = await responseTask.Content.ReadAsStringAsync();
                
            //}
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

