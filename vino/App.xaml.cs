using Xamarin.Forms;

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
