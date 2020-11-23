namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdQueryLookupModel
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}