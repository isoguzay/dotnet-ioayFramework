﻿using ioayFramework.Core.DataAccess;
using ioayFramework.Core.DataAccess.EntityFramework;
using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.Business.Concrete.Managers;
using ioayFramework.Northwind.DataAccess.Abstract;
using ioayFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
        }
    }
}