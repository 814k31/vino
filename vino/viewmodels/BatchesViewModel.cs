using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Newtonsoft.Json;

using vino.models;

namespace vino.viewmodels
{
    public class BatchesViewModel : INotifyPropertyChanged
    {
        private BindingList<BatchViewModel> batches;
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<BatchViewModel> Collection
        {
            get { return this.batches; }
        }

        public BatchesViewModel()
        {
            this.batches = new BindingList<BatchViewModel>();
            this.fetchBatches();
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

        async private void fetchBatches()
        {
            var restService = new RestService();
            var batchesJsonString = await restService.get("https://vino-api.azurewebsites.net/api/batches");
            Debug.WriteLine(@"\tbatchesJsonString!!! {0}", batchesJsonString);
            var batchList = JsonConvert.DeserializeObject<List<Batch>>(batchesJsonString);

            batchList.ForEach(batch => {
                Debug.WriteLine(@"\tBATCH!!! {0}", batch.Name);
                this.batches.Add(new BatchViewModel(batch));
            });
        }

        void OnPropertyChanged(string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
