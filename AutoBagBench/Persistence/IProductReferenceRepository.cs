namespace AutoBagBench.Persistence
{
    public interface IProductReferenceRepository : IRepository<ProductReference>
    {
        ProductReference GetByReferenceName(string refererence);
    }
}
