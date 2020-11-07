using System.Collections.ObjectModel;

namespace vino
{
    public class Batches
    {
        private ObservableCollection<Batch> batches;

        public Batches()
        {
            this.batches = new ObservableCollection<Batch>();
        }

        public void add(Batch newBatch)
        {
            this.batches.Add(newBatch);
        }

        public ReadOnlyObservableCollection<Batch> getCollection()
        {
            ReadOnlyObservableCollection<Batch> observableBatches = (
                new ReadOnlyObservableCollection<Batch>(batches)
            );

            return observableBatches;
        }
    }
}
