using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vino
{
    public partial class App : Application
    {
        public App()
        {
            var batches = new Batches();
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
