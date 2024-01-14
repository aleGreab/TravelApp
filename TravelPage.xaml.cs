using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Windows.Input;

namespace CarTravel;

public partial class TravelPage : ContentPage
{
    private List<string> images = new List<string>() { "paris_turn.jpg", "cafe_paris.jpg", "disney_land.jpg", "rome_colloseum.jpg", 
            "pisa_tower.jpg", "viena_intrare.jpg", "viena_targ.jpg", "cafe_paris.jpg", "flags.jpg", "gelato.jpg", "milan.jpg",
            "milan1.jpg", "rest.jpg", "trevi.jpg", "macarons.jpg"};

    private List<string> userAddedUrls = new List<string>();

    private int currentIndex = 0;
	public TravelPage()
	{
		InitializeComponent();
        userAddedUrls = new List<string>();
        img.Source = ImageSource.FromFile(images[currentIndex]);
    }
    private async void NextImage(object sender, EventArgs e)
    {
        currentIndex++;
        if (currentIndex >= userAddedUrls.Count)
        {
            currentIndex = 0; 
        }
        LoadImage(userAddedUrls[currentIndex]);
    }
    private async void PrevImg(object sender, EventArgs e)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = userAddedUrls.Count - 1;
        }
        LoadImage(userAddedUrls[currentIndex]);
    }
    private ICommand loadImageCommand;
    public ICommand LoadImageCommand
    {
        get
        {
            if (loadImageCommand == null)
            {
                loadImageCommand = new Command<string>(LoadImage);
            }
            return loadImageCommand;
        }
    }
    private void LoadImage(string imageUrl)
    {
        ImageSource imageSource;

        if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri) && uri.Scheme != "file")
        {
            // Imagine de la adresa web
            imageSource = new UriImageSource { Uri = uri };
        }
        else
        {
            // Imagine locala
            imageSource = new FileImageSource { File = imageUrl };
        }

        img.Source = imageSource;
    }

    private async void Add_Url(object sender, EventArgs e)
    {
        var imageUrl = photoUrl.Text;

        if (!string.IsNullOrWhiteSpace(imageUrl))
        {
            userAddedUrls.Add(imageUrl);
            currentIndex = userAddedUrls.Count - 1;
            LoadImage(imageUrl);
            photoUrl.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Please enter a valid URL.", "OK");
        }
    }
    private async void TapGestureRecognizer_TappedForImg(object sender, TappedEventArgs e)
    {
        await img.FadeTo(0.5, 300);
        await img.FadeTo(1);
	}
}