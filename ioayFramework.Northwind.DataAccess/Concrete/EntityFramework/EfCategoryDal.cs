using ioayFramework.Core.DataAccess.EntityFramework;
using ioayFramework.Northwind.DataAccess.Abstract;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
        //public List<Category> GetCategories()
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {

        //    }
        //}
    }
}
