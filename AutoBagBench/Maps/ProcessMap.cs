using FluentNHibernate.Mapping;

namespace AutoBagBench.Maps
{
    public class ProcessMap:ClassMap<ProcessData>
    {
        public ProcessMap()
        {
           
            Id(x => x.ProcessGuid).GeneratedBy.Assigned();
            Map(x => x.Target);
            Map(x => x.OutputQuantity);
            Map(x => x.RejectQuantity);
            Map(x => x.Locked);
            Map(x => x.StartDateTime);
            Map(x => x.FinishDateTime).Nullable();
            Map(x => x.OperatorId);
            Map(x => x.EquipmentId);
            Map(x => x.IsCompleted);
            Map(x => x.ReferenceName);
            Map(x => x.OrderNumber);
            Table("Process");
        }
    }
}
