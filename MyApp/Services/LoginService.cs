
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class LoginService : ILoginRepository
    {
        private const string baseUrl = "http://192.168.1.17:45455/api/";
        public async Task<UserInfo> Login(string username, string password)
        {         
                
                    var userInfo = new UserInfo();
                    var client = new HttpClient();

                    string url = baseUrl + ("Authenticate" + "?username=" + username + "&password=" + password);
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
                        return await Task.FromResult(userInfo);
                        //return await Task.FromResult(userInfo);

                    }
                    else
                    {
                        return null;
                    }
                
            
        }
        
    }
}
