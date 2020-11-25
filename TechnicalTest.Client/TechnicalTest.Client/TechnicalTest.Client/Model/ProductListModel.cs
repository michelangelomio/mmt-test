using System.Collections.Generic;

namespace TechnicalTest.Client.Model
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            Products = new List<ProductModel>();
        }

        public List<ProductModel> Products { get; set; }
    }
}