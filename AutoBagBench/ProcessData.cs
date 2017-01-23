using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBagBench
{
    public class ProcessData
    {
      
        public virtual Guid ProcessGuid { get; set; }
        public virtual int Target { get; set; }
        public virtual int OutputQuantity { get; set; }
        public virtual int RejectQuantity { get; set; }
        public virtual bool Locked { get; set; }
        public virtual DateTime StartDateTime { get; set; }
        public virtual DateTime FinishDateTime { get; set; }
        public virtual Guid OperatorId { get; set; }
        public virtual Guid EquipmentId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual bool IsCompleted { get;  set; }
        public virtual string ReferenceName { get; set; }
        public virtual string OrderNumber { get; set; }
    }
}
