using MyApp.ViewModels;

namespace MyApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
    }

    public LoginPage(LoginPageViewModel loginPageViewModel)
    {
		InitializeComponent();
		this.BindingContext = loginPageViewModel;
	}
}