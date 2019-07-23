using ioayFramework.Core.DataAccess.EntityFramework;
using ioayFramework.Northwind.DataAccess.Abstract;
using ioayFramework.Northwind.Entities.ComplexTypes;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleDetail> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.UserId equals user.Id
                             where ur.UserId == user.Id
                             select new UserRoleDetail
                             {
                                 RoleName = r.Name
                             };
                return result.ToList();
            }
        }
    }
}
