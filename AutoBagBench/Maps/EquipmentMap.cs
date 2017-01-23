using FluentNHibernate.Mapping;

namespace AutoBagBench.Maps
{
    public class EquipmentMap:ClassMap<Equipment>
    {
        public EquipmentMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.EquipmentName);
            Table("Equipment");
        }
    }
}
