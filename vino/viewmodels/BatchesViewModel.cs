using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Linq;

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

        async private void addRemote(Batch batch)
        {
            var restService = new RestService();
            var url = "https://vino-api.azurewebsites.net/api/batches/";
            var json = JsonConvert.SerializeObject(batch);
            var batchJsonString = await restService.post(url, json);
            var batchFromServer = JsonConvert.DeserializeObject<Batch>(batchJsonString);

            Debug.WriteLine(@"\tBATCH!!! {0}", batchFromServer.Name);
            this.add(batchFromServer);
        }

        public BatchViewModel get(int id)
        {
            var batches = this.batches.Where(itrBatch => itrBatch.Batch.Id == id);

            return batches.First();
        }

        async private void fetchBatches()
        {
            var restService = new RestService();
            var batchesJsonString = await restService.get("https://vino-api.azurewebsites.net/api/batches/");
            Debug.WriteLine(@"\tbatchesJsonString!!! {0}", batchesJsonString);
            var batchList = JsonConvert.DeserializeObject<List<Batch>>(batchesJsonString);

            batchList.ForEach(batch => {
                Debug.WriteLine(@"\tBATCH!!! {0}", batch.Name);
                var batchViewModel = this.get(batch.Id);

                if (batchViewModel != null)
                {
                    this.batches.Remove(batchViewModel);
                }

                this.batches.Add(new BatchViewModel(batch));
            });
        }

        async private void updateBatch(Batch batch)
        {
            var restService = new RestService();

            var url = "https://vino-api.azurewebsites.net/api/batches/" + batch.Id;
            var json = JsonConvert.SerializeObject(batch);
            var batchesJsonString = await restService.put(url, json);

            Debug.WriteLine(@"\tbatchesJsonString!!! {0}", batchesJsonString);
            var updatedBatch = JsonConvert.DeserializeObject<Batch>(batchesJsonString);

            var batchViewModel = this.get(batch.Id);
            this.batches[this.batches.IndexOf(batchViewModel)] = new BatchViewModel(updatedBatch);
            this.OnPropertyChanged(nameof(this.Collection));
        }

        void OnPropertyChanged(string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
