using System;
using Xamarin.Forms;

namespace vino
{
    public partial class BatchForm : ContentPage
    {
        private Batch batch;
        private Action<bool> onSubmit;
        private string title;

        public Batch Batch
        { get { return this.batch; } }

        public string TitleForm
        { get { return this.title; } }

        public BatchForm(Batch batch, string title, Action<bool> onSubmit)
        {
            this.batch = batch;
            this.onSubmit = onSubmit;
            this.title = title;

            InitializeComponent();

            BindingContext = this;
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
