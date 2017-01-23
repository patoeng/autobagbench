using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AutoBagBench.Maps
{
    public class ProductReferenceMap: ClassMap<ProductReference>
    {
        public ProductReferenceMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned(); 
            Map(x => x.ReferenceName);
            Map(x => x.AccessoriesType);
            Map(x => x.BagType);
            Map(x => x.ArticleNumber);
            Map(x => x.GroupingSize);
            Table("ProductReference");
        }
    }
}
