using System;

namespace OrmBenchmark
{
    public class SimpleEntity
    {
        public virtual long Id { get; set; }

        public virtual string StringField1 { get; set; }
        public virtual string StringField2 { get; set; }
        public virtual string StringField3 { get; set; }


        public virtual long LongField1 { get; set; }
        public virtual long LongField2 { get; set; }
        public virtual long LongField3 { get; set; }

        public virtual DateTime DateField1 { get; set; }
        public virtual DateTime DateField2 { get; set; }
        public virtual DateTime DateField3 { get; set; }
    }
}
