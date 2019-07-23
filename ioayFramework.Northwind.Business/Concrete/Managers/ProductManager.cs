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
using ioayFramework.Core.Aspects.PostSharp.ExceptionAspects;
using ioayFramework.Core.Aspects.PostSharp.PerformanceAspects;
using System.Threading;
using ioayFramework.Core.Aspects.PostSharp.AuthorizationAspects;

namespace ioayFramework.Northwind.Business.Concrete.Managers
{
    /*If logaspect decleres the beginnig at class, all methods will log*/

    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager),120)]
        [PerformanceCounterAspect(1)]
        [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
        {
            //Testing for Performance Aspect
            Thread.Sleep(3000);
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

        [FluentValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
