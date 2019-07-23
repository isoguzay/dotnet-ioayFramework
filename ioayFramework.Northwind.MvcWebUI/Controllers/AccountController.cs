using ioayFramework.Core.CrossCuttingConcerns.Security.Web;
using ioayFramework.Northwind.Business.Abstract;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ioayFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string username, string password)
        {
            var user = _userService.GetByUserNameAndPassword(username, password);

            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(2),
                    _userService.GetUserRoleDetails(user).Select(u => u.RoleName).ToArray(), 
                    false,
                    user.FirstName,
                    user.LastName);

                return "User is authenticated.";
            }
            else
            {
                return "User is not authenticated!";
            }
        }
    }
}