using Microsoft.AspNetCore.Mvc;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Interfaces;


namespace YangiBozor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;

        public HomeController(IUserService service) => this.service = service;

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Registrate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await service.GetAsync(u => u.UserName == username && u.Password == password);
            if (user == null)
                return RedirectToAction("Login", "Home");
            return RedirectToAction("Index", "User", new { id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Registrate(UserForCreationDto dto)
        {
            var user = await service.AddAsync(dto);
            return RedirectToAction("Index", "User", new { id = user.Id });

        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}