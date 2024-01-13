using CarTravel.Models;

namespace CarTravel;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (CarList)BindingContext;
        await App.Database.SaveCarListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (CarList)BindingContext;
        await App.Database.DeleteCarListAsync(slist);
        await Navigation.PopAsync();
    }
}