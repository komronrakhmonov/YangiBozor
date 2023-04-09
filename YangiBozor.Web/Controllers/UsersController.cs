using Microsoft.AspNetCore.Mvc;
using YangiBozor.Service.DTOs.UserDto;
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

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl, FirstName, LastName, Phone, UserName, Password, Role")]UserForCreationDto user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }
            await this._userService.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }
        //Get: Users/Details/1
        public async Task<IActionResult> Details(string UserName)
        {
            var usersDetails = await this._userService.GetAsync(u=> u.UserName == UserName);
            if(usersDetails == null)
            {
                return NotFound();
            }
            return View(usersDetails);
        }

    }
}
