using Xamarin.Forms;

using vino.viewmodels;

namespace vino
{
    public partial class MainPage : ContentPage
    {
        BatchesViewModel batches;

        public BatchesViewModel Batches
        { get { return this.batches; } }

        public MainPage(BatchesViewModel batches)
        {
            this.batches = batches;
            this.InitializeComponent();

            this.BindingContext = this;
        }

        async void onButtonClickedAdd(System.Object sender, System.EventArgs e)
        {
            BatchViewModel newBatch = new BatchViewModel();
            BatchForm batchForm = new BatchForm(
                newBatch,
                "Create Batch",
                async shouldCreate =>
                {
                    if (shouldCreate)
                    {
                        this.batches.add(newBatch);
                    }

                    await Navigation.PopModalAsync();
                }
            );

            await Navigation.PushModalAsync(batchForm);
        }

        async void onListViewItemClicked(System.Object sender, System.EventArgs e)
        {
            var listViewBatches = (ListView) sender;
            var batch = (BatchViewModel) listViewBatches.SelectedItem;

            var batchPage = new BatchPage(this.batches, batch);

            await Navigation.PushAsync(batchPage);
        }
    }
}
