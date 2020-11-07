﻿using System.Collections.ObjectModel;
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

        async void onButtonClickedAdd(System.Object sender, System.EventArgs e)
        {
            Batch newBatch = new Batch("");
            BatchForm batchForm = new BatchForm(newBatch);

            await Navigation.PushModalAsync(batchForm);

            this.batches.add(newBatch);
        }
    }
}
