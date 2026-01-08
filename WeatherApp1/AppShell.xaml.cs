using WeatherApp1.Views;

namespace WeatherApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AllWeathers), typeof(AllWeathers));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
