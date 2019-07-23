using ioayFramework.Northwind.Business.Abstract;
using ioayFramework.Northwind.DataAccess.Abstract;
using ioayFramework.Northwind.Entities.ComplexTypes;
using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _userDal.Get(u => u.UserName == username & u.Password == password);
        }

        public List<UserRoleDetail> GetUserRoleDetails(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
