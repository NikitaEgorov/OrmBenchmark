using FluentNHibernate.Mapping;

namespace OrmBenchmark.NHibernate
{
    internal sealed class SimpleEntityMap : ClassMap<SimpleEntity>
    {
        public SimpleEntityMap()
        {
            Table("ORM_BENCHMARK_TABLE");
            ReadOnly();

            Id(x => x.Id);

            Map(x => x.StringField1);
            Map(x => x.StringField2);
            Map(x => x.StringField3);

            Map(x => x.LongField1);
            Map(x => x.LongField2);
            Map(x => x.LongField3);

            Map(x => x.DateField1);
            Map(x => x.DateField2);
            Map(x => x.DateField3);
        }
    }
}