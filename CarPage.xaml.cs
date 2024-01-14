using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CarTravel;

public partial class CarPage : ContentPage
{
    private List<string> car_img = new List<string>() {"amg_a35.jpg", "bentley.png", "s_class.jpg", "audi_a4.jpg", "audi_rs7.jpg", "audi_rsq8.jpg", 
    "vw_arteon.jpg", "vw_golf7.jpg", "vw_tiguan.jpg", "vw_touareg.jpg", "vw1.jpg", "bentley1.jpg", "lambo1.jpg", "lambo2.jpg", "skoda.jpg"};

    private List<string> userAddedUrls = new List<string>();

    private int currentIndex;
    public CarPage()
	{
		InitializeComponent();
        userAddedUrls = new List<string>();
    }
    private async void NextImg(object sender, EventArgs e)
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

        photos.Source = imageSource;
    }


    private async void Add_url(object sender, EventArgs e)
    {
        var imageUrl = imgUrl.Text;

        if (!string.IsNullOrWhiteSpace(imageUrl))
        {
            userAddedUrls.Add(imageUrl);
            currentIndex = userAddedUrls.Count - 1;
            LoadImage(imageUrl);
            imgUrl.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Please enter a valid URL.", "OK");
        }
    }

}