using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace vino
{
    public partial class MainPage : ContentPage
    {
        Batches batches;

        public ReadOnlyObservableCollection<Batch> Batches
        { get { return batches.getCollection(); } }

        public MainPage()
        {
            this.batches = new Batches();
            InitializeComponent();

            BindingContext = this;
        }

        void onButtonClickedAdd(System.Object sender, System.EventArgs e)
        {
            this.batches.add(new Batch(this.batches.getCollection().Count.ToString()));
        }
    }
}
