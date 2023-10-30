using MyApp.ViewModels;

namespace MyApp.Pages;

public partial class EmployeeListPage : ContentPage
{
    public EmployeeListPage()
    {
        InitializeComponent();
        
    }

    public EmployeeListPage(EmployeeListModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    private async void Save_Button_cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutPage());
    }

    
}