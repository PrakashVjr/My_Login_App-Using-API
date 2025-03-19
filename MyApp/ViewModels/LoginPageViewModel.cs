
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyApp.Models;
using MyApp.Pages;
using MyApp.Services;
using Newtonsoft.Json;

namespace MyApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;
        readonly ILoginRepository loginRepository = new LoginService();

        private string connectionString = "Server=localhost;Database=SevenDB;User Id=sa;Password=P@ssw0rd;"; // Hardcoded Credentials
        private string apiKey = "123456-abcdef-7890ghijkl"; // Hardcoded API Key
        private static readonly HttpClient httpClient = new HttpClient();
        
        public LoginPageViewModel()
        {
            var UserName = "prakash";
            var Password = "Demo@1234";
            var Email = "Prakash@yopmail.com";

            var ApiKey = "AIzaSyBGCs1b8NQfNn3N1Aomk2iSsW17zFCUw1M";
        }

        [ICommand]
        public async void Login()
        { 
            if(!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                UserInfo userInfo = await loginRepository.Login(UserName, Password);
                if(userInfo != null)
                {
                    string userDetails = JsonConvert.SerializeObject(userInfo);
                    Preferences.Set(nameof(App.UserInfo), userDetails);

                    App.UserInfo = userInfo;

                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Invalid login, try again!!!", cancel: "OK");
                }
                
            }
        }

        // Critical: SQL Injection vulnerability
        private async void LoginUser(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    await DisplayAlert("Success", "Login successful!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid credentials", "OK");
                }
            }
        }

        // High: Weak Hashing Algorithm (MD5)
        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Medium: Insecure API Call (Hardcoded API Key & No SSL verification)
        private async void FetchData()
        {
            string url = "http://example.com/api/data?key=" + apiKey;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string responseData = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseData); // Low: Logging sensitive data
        }

        // Critical: Remote Code Execution Risk
        private void ExecuteCommand(string input)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/C " + input);
        }

        // Low: Debugging Information Disclosure
        private async void DebugInfo()
        {
            await DisplayAlert("Debug Info", connectionString, "OK");
        }
        
    }
}
