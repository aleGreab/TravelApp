using System.Collections.ObjectModel;

namespace CarTravel;

public partial class CarPage : ContentPage
{
    private List<string> car_img = new List<string>() {"amg_a35.jpg", "bentley.png", "s_class.jpg", "audi_a4.jpg", "audi_rs7.jpg", "audi_rsq8.jpg", 
    "vw_arteon.jpg", "vw_golf7.jpg", "vw_tiguan.jpg", "vw_touareg.jpg", "vw1.jpg", "bentley1.jpg", "lambo1.jpg", "lambo2.jpg", "skoda.jpg"};
    private int currentIndex;
    public CarPage()
	{
		InitializeComponent();
    }
    private async void NextImg(object sender, EventArgs e)
    {
        currentIndex++;
        if (currentIndex >= car_img.Count)
        {
            currentIndex = 0;
        }
        photos.Source = ImageSource.FromFile(car_img[currentIndex]);
    }
    private async void PrevImg(object sender, EventArgs e)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = car_img.Count - 1;
        }
        photos.Source = ImageSource.FromFile(car_img[currentIndex]);
    }
}