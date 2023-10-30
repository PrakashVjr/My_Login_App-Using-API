using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class EmployeeListService : ILoginRepository
    {
        private const string Url = "http://192.168.1.17:45455/api/GetAll";
        public async Task<List<UserInfo>> GetUserInfo()
        {
            try
            {
                var ReturnResponse = new List<UserInfo>();

                var userInfo = new UserInfo();

                var client = new HttpClient();

                //var Url = await client.GetAsync("http://192.168.1.17:45455/api/");

               // client.BaseAddress = new Uri(Url);
                HttpResponseMessage response = await client.GetAsync(Url);



                //client.BaseAddress = new Uri(baseUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Content = await response.Content.ReadAsStringAsync();

                    var deserilationContent = JsonConvert.DeserializeObject<List<UserInfo>>(Content);

                    if (deserilationContent?.Count > 0)
                    {
                        ReturnResponse = deserilationContent;
                    }
                }
                return ReturnResponse;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            
            
        }

        public Task<UserInfo> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
