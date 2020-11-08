using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace vino
{
    public partial class BatchPage : ContentPage
    {
        private Batches batches;
        private Batch batch;

        public Batch Batch
        { get { return this.batch; } }

        public BatchPage(Batches batches, Batch batch)
        {
            this.batches = batches;
            this.batch = batch;

            InitializeComponent();

            BindingContext = this;
        }
    }
}
