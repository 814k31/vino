using System;

namespace vino.models
{
    public class Batch
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public Batch() {}

        public Batch(string name)
        {
            this.Name = name;
        }

        public Batch(Batch batch)
        {
            this.DateCreated = batch.DateCreated;
            this.DateUpdated = batch.DateUpdated;
            this.Name = batch.Name;
            this.Id = batch.Id;
        }
    }
}
