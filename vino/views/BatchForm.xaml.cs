using System;
using Xamarin.Forms;

using vino.viewmodels;

namespace vino
{
    public partial class BatchForm : ContentPage
    {
        private BatchViewModel batch;
        private Action<bool> onSubmit;
        private string title;

        public BatchViewModel Batch
        { get { return this.batch; } }

        public string TitleForm
        { get { return this.title; } }

        public BatchForm(BatchViewModel batch, string title, Action<bool> onSubmit)
        {
            this.batch = batch;
            this.onSubmit = onSubmit;
            this.title = title;

            this.InitializeComponent();

            this.BindingContext = this;
        }

        void onButtonClickedSubmit(System.Object sender, System.EventArgs e)
        {
            this.onSubmit(true);
        }

        void onButtonClickedCancel(System.Object sender, System.EventArgs e)
        {
            this.onSubmit(false);
        }
    }
}
