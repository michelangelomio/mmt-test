namespace CleanArchitecture.Application.Product.Queries.GetProductBytId
{
    public class GetProductByIdQueryLookupModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}