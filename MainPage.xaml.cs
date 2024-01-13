namespace CarTravel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void TapGestureRecognizer_TappedForBot(object sender, TappedEventArgs e)
        {
            await imgBot.RotateTo(30);
            await imgBot.RotateTo(0);

        }
    }

}
