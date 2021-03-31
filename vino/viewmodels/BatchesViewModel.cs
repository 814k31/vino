using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Linq;
using vino.models;
using System;

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
            var url = "https://10.0.2.2:5001/api/batches/";
            var json = JsonConvert.SerializeObject(batch);
            var batchJsonString = await restService.post(url, json);
            var batchFromServer = JsonConvert.DeserializeObject<Batch>(batchJsonString);

            Debug.WriteLine("\tBATCH!!! {0}", batchFromServer.Name);
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
            List<Batch> batchList = null;

            var batchesJsonString = await restService.get("https://10.0.2.2:5001/api/batches/");
            Debug.WriteLine("batchesJsonString!!!", batchesJsonString);
            batchList = JsonConvert.DeserializeObject<List<Batch>>(batchesJsonString);


            batchList.ForEach(batch => {
                Debug.WriteLine("BATCH!!!", batch.Name);
                this.batches.Add(new BatchViewModel(batch));
            });
            OnPropertyChanged(nameof(Collection));
        }

        async private void updateBatch(Batch batch)
        {
            var restService = new RestService();

            var url = "https://10.0.2.2:5001/api/batches/" + batch.Id;
            var json = JsonConvert.SerializeObject(batch);
            var batchesJsonString = await restService.put(url, json);

            Debug.WriteLine("batchesJsonString!!! {0}", batchesJsonString);
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
