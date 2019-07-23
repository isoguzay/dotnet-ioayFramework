using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ioayFramework.Northwind.WebApi.Sample.Controllers
{
    public class ProductsController : ApiController
    {
        public IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
