using MyApp.Models;
using MyApp.Pages;
using MyApp.ViewModels;

namespace MyApp;

public partial class App : Application
{
	public static UserInfo UserInfo;
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new HomePage();
    }
}
