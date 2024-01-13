using System.Collections.ObjectModel;

namespace CarTravel;

public partial class CarPage : ContentPage
{
    public CarPage()
	{
		InitializeComponent();
    }

    private async void TapGestureRecognizer_TappedForScaleAnimation(object sender, TappedEventArgs e)
    {
		await imgScale.ScaleTo(2, 2000);
		await imgScale.ScaleTo(1, 2000);
    }
    private async void TapGestureRecognizer_TappedForScaleAnimation1(object sender, TappedEventArgs e)
    {
        await img1Scale.ScaleTo(2, 2000);
        await img1Scale.ScaleTo(1, 2000);
    }
    private async void TapGestureRecognizer_TappedForScaleAnimation2(object sender, TappedEventArgs e)
    {
        await img2Scale.ScaleTo(2, 2000);
        await img2Scale.ScaleTo(1, 2000);
    }
}