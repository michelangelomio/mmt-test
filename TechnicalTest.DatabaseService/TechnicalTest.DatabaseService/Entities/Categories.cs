using System.Collections.Generic;

namespace TechnicalTest.DatabaseService.Entities
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}