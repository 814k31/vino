using System;

namespace vino.models
{
    public class Batch
    {
        private DateTime dateCreated;
        private DateTime? dateUpdated;
        private string name;

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

        public string getName()
        {
            return this.name;
        }

        public string setName(string newName)
        {
            return this.name = newName;
        }
    }
}
