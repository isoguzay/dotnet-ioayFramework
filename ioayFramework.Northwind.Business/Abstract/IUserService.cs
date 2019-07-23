using ioayFramework.Northwind.Entities.ComplexTypes;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string username, string password);
        List<UserRoleDetail> GetUserRoleDetails(User user);
    }
}
