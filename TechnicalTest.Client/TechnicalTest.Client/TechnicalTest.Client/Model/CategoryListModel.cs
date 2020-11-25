using System.Collections.Generic;

namespace TechnicalTest.Client.Model
{
    public class CategoryListModel
    {
        public CategoryListModel()
        {
            Categories = new List<CategoryModel>();
        }

        public List<CategoryModel> Categories { get; set; }
    }
}