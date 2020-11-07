using System.Collections.ObjectModel;

namespace vino
{
    public class Batches
    {
        private ObservableCollection<int> batches;

        public Batches()
        {
            this.batches = new ObservableCollection<int>();
            this.batches.Add(1);
            this.batches.Add(2);
        }

        public void add(int newBatch)
        {
            this.batches.Add(newBatch);
        }

        public ReadOnlyObservableCollection<int> getCollection()
        {
            ReadOnlyObservableCollection<int> observableBatches = (
                new ReadOnlyObservableCollection<int>(batches)
            );

            return observableBatches;
        }
    }
}
