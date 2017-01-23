using System;
using AutoBagBench.Persistence;

namespace AutoBagBench
{
    public class Process
    {

        private static readonly IRepository<ProcessData> ProcessRepository = new ProcessRepository();
        private ProcessData _processData= new ProcessData();

        public  Guid ProcessGuid
        {
            get { return _processData.ProcessGuid; }
             set { _processData.ProcessGuid = value; }
        }

        public virtual int Target
        {
            get { return _processData.Target; }
            set { _processData.Target = value; }
        }
        public virtual int OutputQuantity
        {
            get { return _processData.OutputQuantity; }
            protected set { _processData.OutputQuantity = value; }
        }
        public virtual int RejectQuantity
        {
            get { return _processData.RejectQuantity; }
            protected set { _processData.RejectQuantity = value; }
        }
        public virtual bool Locked
        {
            get { return _processData.Locked; }
            protected set { _processData.Locked = value; }
        }
        public virtual DateTime StartDateTime
        {
            get { return _processData.StartDateTime; }
            set { _processData.StartDateTime = value; }
        }
        public virtual DateTime FinishDateTime
        {
            get { return _processData.FinishDateTime; }
            set { _processData.FinishDateTime = value; }
        }
        public virtual string ReferenceName
        {
            get { return _processData.ReferenceName; }
            set { _processData.ReferenceName = value; }
        }
        public virtual string OrderNumber{
            get { return _processData.OrderNumber; }
            set { _processData.OrderNumber = value; }
        }
        public virtual Guid OperatorId { get; protected set; }
        public virtual Guid EquipmentId
        {
            get { return _processData.EquipmentId; }
            set { _processData.EquipmentId = value; }
        }
        public virtual Guid ProductId { get; set; }
        public virtual bool IsCompleted
        {
            get { return _processData.IsCompleted; }
            set { _processData.IsCompleted = value; }
        }
        public Operator ProductionOperator { get; protected set; }
        public Equipment Equipment { get; protected set; }
        public ProductReference Product { get; set; }
        public int ProcessableQuantity { get; set; }

        public bool Traceability { get; set; }

     
        public event NoParamDelegate TargetAchievedEvent;
        public Process()
        {
            ProcessGuid = Guid.NewGuid();
            ProductionOperator = new Operator();
            Equipment = new Equipment();
            Product = new ProductReference();
            ProcessableQuantity = -1;
            Traceability = SettingHelper.Traceability();
        }
        public Process(ProductReference product, int target, Operator oOperator, Equipment equipment,string orderNumber)
        {
             New( product, target, oOperator,equipment,orderNumber);
        }
        public void New(ProductReference product, int target, Operator oOperator,Equipment equipment,string orderNumber)
        {
            Target = target;
            ProductionOperator = oOperator;
            OperatorId = oOperator.Id;
            Equipment = equipment;
            EquipmentId = Equipment.Id;
            StartDateTime = DateTime.Now;
            OrderNumber = orderNumber;
            ProcessRepository.Add(_processData);
        }

        public void SetOutputQuantity(int data)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }

            OutputQuantity = data;
            if (OutputQuantity >= Target)
            {
                if (TargetAchievedEvent != null) TargetAchievedEvent();
            }
            SaveOrUpdate();
        }
        public void IncreaseOutputQuantity(int deltaQuantity)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }
           
            OutputQuantity += deltaQuantity;
            if (OutputQuantity >= Target)
            {
                if (TargetAchievedEvent != null) TargetAchievedEvent();
            }
            SaveOrUpdate();
        }

        public void DecreaseOutputQuantity(int deltaQuantity)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }
           
            if (OutputQuantity == 0)
            {
                throw new AutoBagException("Can not decrease, Output Quantity already zero");
            }
            OutputQuantity -= deltaQuantity;
            SaveOrUpdate();
        }

        public void IncreaseRejectQuantity(int deltaQuantity)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }
            RejectQuantity += deltaQuantity;
            SaveOrUpdate();
        }
        public void DecreaseRejectQuantity(int deltaQuantity)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }

            if (RejectQuantity == 0)
            {
                throw new AutoBagException("Can not decrease, Reject Quantity already zero");
            }
            RejectQuantity -= deltaQuantity;
            SaveOrUpdate();
        }
        public void Lock()
        {
            Locked = true;
        }
        public void Unlock()
        {
            Locked = false;
        }
        public void SaveOrUpdate()
        {
            FinishDateTime = DateTime.Now;
            try
            {
                var J = ProcessRepository.Get(_processData.ProcessGuid);
                if (J != null)
                {
                    ProcessRepository.Update(_processData);
                }
                else
                {
                    ProcessRepository.Add(_processData);
                }
            }
            catch (Exception)
            {
                
            }
        }
        public void SaveOrUpdate(bool completed)
        {
            this.IsCompleted = completed;
            var J = ProcessRepository.Get(_processData.ProcessGuid);
            if (J != null)
            {
                ProcessRepository.Update(_processData);
            }
            else
            {
                ProcessRepository.Add(_processData);
            }
        }
        public  void ReloadLastRunning(string id)
        {
            if(_processData==null)_processData = new ProcessData();
            _processData = ProcessRepository.Get(new Guid(id));
            if (_processData == null)
            {
                _processData = new ProcessData();
            }
        }

        public void SetRejectQuantity(int data)
        {
            if (Locked)
            {
                throw new AutoBagException("AutoBag is Locked.");
            }

            RejectQuantity = data;
            SaveOrUpdate();
        }

        public static ProductReference GetProductReferenceByName(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                IProductReferenceRepository repo = new ProductReferenceRepository();
                return repo.GetByReferenceName(name);
            }
            else
            {
                return new ProductReference();
            }
        }

        public void CompleteProcess()
        {
            _processData.IsCompleted = true;
            _processData.FinishDateTime = DateTime.Now;
            ProcessRepository.Update(_processData);
        }
    }
}
