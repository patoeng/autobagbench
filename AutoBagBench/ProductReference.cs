using System;

namespace AutoBagBench
{
    public  class ProductReference
    {
        public virtual Guid Id { get; set; }
        public virtual string ReferenceName { get; set; }

        public virtual BagType BagType { get; set; }

        public virtual AccessoriesType AccessoriesType { get; set; }
        public virtual string ArticleNumber { get; set; }
        
        public virtual int GroupingSize { get; set; }
        public virtual string LabelFile { get; set; }
    }
}
