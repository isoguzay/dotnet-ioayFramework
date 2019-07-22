using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.Entities.Concrete;
using ioayFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ioayFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = new ProductCategoryListViewModel
            {
                Products = _productService.GetAll(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Test",
                QuantityPerUnit = "1",
                UnitPrice = 21
            });

            return "Added Product";
        }
        
        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Laptop - Isoguzay",
                QuantityPerUnit = "1",
                UnitPrice = 25
            },new Product
            {
                CategoryId = 1,
                ProductName = "Laptop - WhoAmI",
                QuantityPerUnit = "1",
                UnitPrice = 30,
                ProductID = 2
            });

            return "Done";
        }
    }
}