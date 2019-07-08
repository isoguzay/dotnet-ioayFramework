using System;
using ioayFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ioayFramework.DataAccess.Test.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();

            Assert.AreEqual(80, result.Count);
             
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList(x => x.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);

        }
    }
}
