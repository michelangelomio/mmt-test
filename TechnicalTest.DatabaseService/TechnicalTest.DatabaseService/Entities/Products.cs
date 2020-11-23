namespace TechnicalTest.DatabaseService.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool FeaturedProduct { get; set; }
        public bool Deleted { get; set; }

        public virtual Categories Category { get; set; }
    }
}