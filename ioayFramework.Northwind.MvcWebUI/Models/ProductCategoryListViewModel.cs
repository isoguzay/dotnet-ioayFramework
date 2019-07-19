using System.Collections.Generic;
using ioayFramework.Northwind.Entities.Concrete;

namespace ioayFramework.Northwind.MvcWebUI.Models
{
    public class ProductCategoryListViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}