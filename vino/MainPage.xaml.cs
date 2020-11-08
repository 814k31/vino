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
                shouldCreate =>
                {
                    if (shouldCreate)
                    {
                        this.batches.add(newBatch);
                    }
                }
            );

            await Navigation.PushModalAsync(batchForm);
        }
    }
}
