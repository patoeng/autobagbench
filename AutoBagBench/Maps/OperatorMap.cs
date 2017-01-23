using FluentNHibernate.Mapping;

namespace AutoBagBench.Maps
{
    public  class OperatorMap:ClassMap<Operator>
    {
        public OperatorMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.EmployeeName);
            Map(x => x.EmployeeNumber);

            Table("Operator");
        }
    }
}
