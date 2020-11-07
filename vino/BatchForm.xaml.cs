using Xamarin.Forms;

namespace vino
{
    public partial class BatchForm : ContentPage
    {
        private Batch batch;

        public BatchForm(Batch batch)
        {
            this.batch = batch;
            InitializeComponent();

            BindingContext = this.batch;
        }

        async void onButtonClickedCreate(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void onButtonClickedCancel(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
