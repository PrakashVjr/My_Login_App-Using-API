namespace MyApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();  
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        // Navigation.PushAsync(new DetailsPage());
        await Shell.Current.Navigation.PushAsync(new EmployeeListPage());
    }
}