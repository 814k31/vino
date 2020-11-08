using Firebase.Database;
using Firebase.Database.Query;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

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

            this.initialiseWithDatabase();
        }

        private async void initialiseWithDatabase()
        {
            var firebaseClient = new FirebaseClient("https://vino-54f1f.firebaseio.com/");
            var results = (await firebaseClient
                .Child("batchTest")
                .OnceAsync<BatchViewModel>()
            );

            results
                .Select(item => new BatchViewModel(new Batch(item.Object.Name)))
                .ToList()
                .ForEach(batch => this.add(batch));
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
