using CarTravel.Models;

namespace CarTravel;

public partial class PlacePage : ContentPage
{
    TravelList tl;
    public PlacePage(TravelList tlist)
    {
        InitializeComponent();
        tl = tlist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var place = (Place)BindingContext;
        await App.Database.SavePlaceAsync(place);
        listView.ItemsSource = await App.Database.GetPlacesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var place = (Place)BindingContext;
        await App.Database.DeletePlaceAsync(place);
        listView.ItemsSource = await App.Database.GetPlacesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ListPlace placel)
        {
            listView.ItemsSource = await App.Database.GetListPlacesAsync(placel.ID);
        }
        else
        {
            await DisplayAlert("Error", "Unexpected BindingContext type.", "OK");
        }
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Place p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Place;
            var lp = new ListPlace()
            {
                TravelListID = tl.ID,
                PlaceID = p.ID
            };
            await App.Database.SaveListPlaceAsync(lp);
            p.ListPlaces = new List<ListPlace> { lp };
            await Navigation.PopAsync();
        }
    }

}