using CarTravel.Models;

namespace CarTravel;

public partial class TripPage : ContentPage
{
	public TripPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (TravelList)BindingContext;
        await App.Database.SaveTravelListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (TravelList)BindingContext;
        await App.Database.DeleteTravelListAsync(slist);
        await Navigation.PopAsync();
    }
}