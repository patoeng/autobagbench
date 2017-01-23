using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBagBench.Persistence
{
    public interface IProductReferenceRepository : IRepository<ProductReference>
    {
        ProductReference GetByReferenceName(string refererence);
    }
}
