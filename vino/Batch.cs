using System;
namespace vino
{
    public class Batch
    {
        private string name;
        private DateTime dateCreated;
        private DateTime? dateUpdated;

        public string Name
        {
            get { return this.name; }
        }

        public Batch(string name)
        {
            this.name = name;
            this.dateCreated = new DateTime();
            this.dateUpdated = null;
        }
    }
}
