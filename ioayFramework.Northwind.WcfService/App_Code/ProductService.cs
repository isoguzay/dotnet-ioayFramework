using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService : IProductService
{
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Product Add(Product product)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product GetById(int productId)
    {
        throw new NotImplementedException();
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        throw new NotImplementedException();
    }

    public Product Update(Product product)
    {
        throw new NotImplementedException();
    }
}