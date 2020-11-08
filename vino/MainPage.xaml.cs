using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace vino
{
    public partial class MainPage : ContentPage
    {
        Batches batches;

        public ReadOnlyObservableCollection<Batch> Batches
        { get { return batches.getCollection(); } }

        public MainPage(Batches batches)
        {
            this.batches = batches;
            InitializeComponent();

            BindingContext = this;
        }

        async void onButtonClickedAdd(System.Object sender, System.EventArgs e)
        {
            Batch newBatch = new Batch("");
            BatchForm batchForm = new BatchForm(
                newBatch,
                "Create Batch",
                async shouldCreate =>
                {
                    if (shouldCreate)
                    {
                        this.batches.add(newBatch);
                    }
                }
            );

            await Navigation.PushModalAsync(batchForm);
        }

        async void onListViewItemClicked(System.Object sender, System.EventArgs e)
        {
            var listViewBatches = (ListView) sender;
            var batch = (Batch) listViewBatches.SelectedItem;

            var batchPage = new BatchPage(this.batches, batch);

            await Navigation.PushAsync(batchPage);
        }
    }
}
