namespace MyApp.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        //double value = args.NewValue;
        //rotatingLabel.Rotation = value;
        //displayLabel.Text = String.Format("The Slider value is {0}", value);
    }
}