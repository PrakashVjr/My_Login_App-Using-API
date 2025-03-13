
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
        
    }
}
