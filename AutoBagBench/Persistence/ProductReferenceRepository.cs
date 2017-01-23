using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace AutoBagBench.Persistence
{
    public class ProductReferenceRepository : Repository<ProductReference>,IProductReferenceRepository
    {
        public ProductReference GetByReferenceName(string refererence)
        {
            refererence = refererence.ToUpper();
            ProductReference data = GetAll().SingleOrDefault(x=>x.ReferenceName==refererence);
            return data ?? new ProductReference();
        }
    }
}
