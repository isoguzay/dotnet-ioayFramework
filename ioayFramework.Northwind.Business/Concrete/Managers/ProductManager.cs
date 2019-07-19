using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.Business.ValidationRules.FluentValidation;
using ioayFramework.Northwind.DataAccess.Abstract;
using ioayFramework.Northwind.Entities.Concrete;
using ioayFramework.Core.Aspects.PostSharp;
using System.Collections.Generic;
using ioayFramework.Core.Aspects.PostSharp.TransactionAspects;
using ioayFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using ioayFramework.Core.Aspects.PostSharp.CacheAspects;
using ioayFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using ioayFramework.Core.Aspects.PostSharp.LogAspects;

namespace ioayFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager),120)]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
