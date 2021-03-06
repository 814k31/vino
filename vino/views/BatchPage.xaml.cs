﻿using Xamarin.Forms;

using vino.viewmodels;

namespace vino
{
    public partial class BatchPage : ContentPage
    {
        private BatchesViewModel batches;
        private BatchViewModel batch;

        public BatchViewModel Batch
        { get { return this.batch; } }

        public BatchPage(BatchesViewModel batches, BatchViewModel batch)
        {
            this.batches = batches;
            this.batch = batch;

            this.InitializeComponent();

            this.BindingContext = this;
        }

        async void onClickedToolBarItemEdit(System.Object sender, System.EventArgs e)
        {
            BatchViewModel batchCopyToEdit = new BatchViewModel(this.batch.Batch); 

            BatchForm batchForm = new BatchForm(
                batchCopyToEdit,
                "Edit Batch",
                async shouldUpdate =>
                {
                    if (shouldUpdate)
                    {
                        this.batch.Name = batchCopyToEdit.Name;
                    }

                    await Navigation.PopModalAsync();
                }
            );

            await Navigation.PushModalAsync(batchForm);
        }
    }
}
