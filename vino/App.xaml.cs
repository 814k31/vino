using Xamarin.Forms;

using vino.models;
using vino.viewmodels;

namespace vino
{
    public partial class App : Application
    {
        public App()
        {
            var batches = new BatchesViewModel();
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(batches));
        }

        protected override void OnStart()
        {
            var restService = new RestService();
            restService.get("https://vino-api.azurewebsites.net/api/batches");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
