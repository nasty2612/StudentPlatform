using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain;
using StudentPlatform.Domain.Repositories.Abstract;
using System.Text.Json;

namespace StudentPlatform.Controllers.User
{
    [Authorize(Roles = "user")]
    public partial class UserController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(DataManager dataManager, IWebHostEnvironment hostingEnvironment,
                              ILogger<UserController> logger, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();

            // Загружаем только услуги этого пользователя
            var allServices = await _dataManager.Services.GetServicesAsync();
            ViewBag.Services = allServices.Where(x => x.UserId == userId);

            return View();
        }

        public async Task<string> SaveImg(IFormFile img)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "img/", img.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await img.CopyToAsync(stream);
            return path;
        }
    }
}
