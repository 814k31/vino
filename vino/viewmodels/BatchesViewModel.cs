using System.Collections.ObjectModel;
using System.ComponentModel;

using vino.models;

namespace vino.viewmodels
{
    public class BatchesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BatchViewModel> batches;
        public event PropertyChangedEventHandler PropertyChanged;

        public BatchesViewModel()
        {
            this.batches = new ObservableCollection<BatchViewModel>();
        }

        public ObservableCollection<BatchViewModel> Collection
        {
            get { return this.batches; }
        }

        public void add(Batch batch)
        {
            this.add(new BatchViewModel(batch));
        }

        public void add(BatchViewModel batch)
        {
            this.batches.Add(batch);
            this.OnPropertyChanged(nameof(this.Collection));
        }

        void OnPropertyChanged(string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
