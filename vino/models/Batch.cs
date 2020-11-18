using System;

namespace vino.models
{
    public class Batch
    {
        public DateTime dateCreated { get; set; }
        public DateTime? dateUpdated { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public Batch() {}

        public Batch(string name)
        {
            this.name = name;
        }

        public Batch(Batch batch)
        {
            this.dateCreated = batch.dateCreated;
            this.dateUpdated = batch.dateUpdated;
            this.name = batch.name;
            this.id = batch.id;
        }
    }
}
