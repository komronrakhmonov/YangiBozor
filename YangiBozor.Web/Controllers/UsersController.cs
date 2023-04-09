using Microsoft.AspNetCore.Mvc;
using YangiBozor.Service.Interfaces;
using YangiBozor.Service.Services;

namespace YangiBozor.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            var Users = _userService.GetAllAsync(null);
            return View(Users);
        }
        //Get: Users/Create
        public IActionResult Create()
        {
            return View();
        }

    }
}
