using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace StudentPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid) return View(model);

            // блокируем при ошибке
            var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);

            // Перенаправляем на ввод кода
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa", new { returnUrl });
            }

            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Неверный логин или пароль!");
            return View(model);
        }

        // Добавляем метод для ввода кода при 2FA
        [HttpGet]
        public async Task<IActionResult> LoginWith2fa(string? returnUrl)
        {
            // Проверяем, есть ли пользователь в промежуточной сессии
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null) return BadRequest();

            // Генерируем сам код
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

            // Отправляем письмо
            var sender = HttpContext.RequestServices.GetRequiredService<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender>();
            await sender.SendEmailAsync(user.Email!, "Код подтверждения", $"Ваш код для входа: {code}");

            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginWith2faViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            // Убираем лишние пробелы, если они есть
            var code = model.TwoFactorCode.Replace(" ", "").Replace("-", "");

            // Проверяем код из письма
            var result = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }

            ModelState.AddModelError(string.Empty, "Неверный код.");
            return View(model);
        }


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, TwoFactorEnabled = true };
                var result = await _userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    // Назначаем роль пользователя
                    await _userManager.AddToRoleAsync(user, "user");
            
                    // Здесь должна быть отправка письма для подтверждения, если нужно
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Асинхронно выходим
            return RedirectToAction("Index", "Home"); // Кидаем на главную
        }


    }
}
