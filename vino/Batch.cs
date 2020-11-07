using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace vino
{
    public class Batch : INotifyPropertyChanged
    {
        private string name;
        private DateTime dateCreated;
        private DateTime? dateUpdated;

        public event PropertyChangedEventHandler PropertyChanged;

        public Batch(string name)
        {
            this.name = name;
            this.dateCreated = new DateTime();
            this.dateUpdated = null;
        }

        public string Name
        {
            get { return this.name; }
            set {
                name = value;
                this.OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
