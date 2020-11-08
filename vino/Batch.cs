using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace vino
{
    public class Batch : INotifyPropertyChanged
    {
        private DateTime dateCreated;
        private DateTime? dateUpdated;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public Batch(string name)
        {
            this.dateCreated = new DateTime();
            this.dateUpdated = null;
            this.name = name;
        }

        public Batch(Batch batch)
        {
            this.dateCreated = batch.dateCreated;
            this.dateUpdated = batch.dateUpdated;
            this.name = batch.name;
        }

        public string Name
        {
            get { return this.name; }
            set {
                this.name = value;
                this.OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
