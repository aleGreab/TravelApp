namespace CarTravel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_TappedForBot(object sender, TappedEventArgs e)
        {
            await imgBot.RotateTo(30);
            await imgBot.RotateTo(0);

        }
    }

}
