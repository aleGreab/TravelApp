namespace CarTravel;

public partial class TravelPage : ContentPage
{
    private List<string> images = new List<string>() { "paris_turn.jpg", "cafe_paris.jpg", "disney_land.jpg", "rome_colloseum.jpg", 
            "pisa_tower.jpg", "viena_intrare.jpg", "viena_targ.jpg", "cafe_paris.jpg", "flags.jpg", "gelato.jpg", "milan.jpg",
            "milan1.jpg", "rest.jpg", "trevi.jpg", "macarons.jpg"}; 
    private int currentIndex = 0;
    public TravelPage()
	{
		InitializeComponent();
        img.Source = ImageSource.FromFile(images[currentIndex]);
    }
    private async void NextImage(object sender, EventArgs e)
    {
        currentIndex++;
        if (currentIndex >= images.Count)
        {
            currentIndex = 0; 
        }
        img.Source = ImageSource.FromFile(images[currentIndex]);
    }
    private async void PrevImg(object sender, EventArgs e)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = images.Count - 1;
        }
        img.Source = ImageSource.FromFile(images[currentIndex]);
    }
    private async void TapGestureRecognizer_TappedForImg(object sender, TappedEventArgs e)
    {
        await img.FadeTo(0.5, 300);
        await img.FadeTo(1);
    }
}