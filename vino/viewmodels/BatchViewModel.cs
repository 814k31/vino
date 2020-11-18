using System.ComponentModel;
using System.Runtime.CompilerServices;

using vino.models;

namespace vino.viewmodels
{
    public class BatchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Batch Batch
        { get; }

        public BatchViewModel()
        {
            this.Batch = new Batch("");
        }

        public BatchViewModel(Batch batch)
        {
            this.Batch = batch;
        }

        public string Name
        {
            get { return this.Batch.Name; }
            set {
                this.Batch.Name = value;
                this.OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
