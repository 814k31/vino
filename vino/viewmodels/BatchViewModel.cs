using System.ComponentModel;
using System.Runtime.CompilerServices;

using vino.models;

namespace vino.viewmodels
{
    public class BatchViewModel : INotifyPropertyChanged
    {
        private Batch batch;
        public event PropertyChangedEventHandler PropertyChanged;

        public BatchViewModel()
        {
            this.batch = new Batch("");
        }

        public BatchViewModel(Batch batch)
        {
            this.batch = batch;
        }

        public Batch Batch
        { get { return this.batch; } }

        public string Name
        {
            get { return this.batch.getName(); }
            set {
                this.batch.setName(value);
                this.OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
