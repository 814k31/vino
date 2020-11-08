using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace vino
{
    public partial class BatchPage : ContentPage
    {
        private Batches batches;
        private Batch batch;

        public Batch Batch
        { get { return this.batch; } }

        public BatchPage(Batches batches, Batch batch)
        {
            this.batches = batches;
            this.batch = batch;

            InitializeComponent();

            BindingContext = this;
        }

        async void onClickedToolBarItemEdit(System.Object sender, System.EventArgs e)
        {
            Batch batchCopyToEdit = new Batch(this.batch);

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
