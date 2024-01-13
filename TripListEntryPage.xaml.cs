using CarTravel.Models;
namespace CarTravel;

public partial class TripListEntryPage : ContentPage
{
	public TripListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTravelListsAsync();
    }
    async void OnTripListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TripPage
        {
            BindingContext = new TravelList()
        });
    }
    async void OnTripListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TripPage
            {
                BindingContext = e.SelectedItem as TravelList
            });
        }
    }
}