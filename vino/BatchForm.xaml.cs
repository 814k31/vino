using System;
using Xamarin.Forms;

namespace vino
{
    public partial class BatchForm : ContentPage
    {
        private Batch batch;
        private Action<bool> onSubmit;

        public BatchForm(Batch batch, Action<bool> onSubmit)
        {
            this.batch = batch;
            this.onSubmit = onSubmit;

            InitializeComponent();

            BindingContext = this.batch;
        }

        async void onButtonClickedCreate(System.Object sender, System.EventArgs e)
        {
            this.onSubmit(true);
            await Navigation.PopModalAsync();
        }

        async void onButtonClickedCancel(System.Object sender, System.EventArgs e)
        {
            this.onSubmit(false);
            await Navigation.PopModalAsync();
        }
    }
}
